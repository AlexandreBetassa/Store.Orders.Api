using Fatec.Store.Framework.Core.Enums;
using Fatec.Store.Orders.Application.v1.Commands.Orders.CreateOrder;
using Fatec.Store.Orders.Application.v1.Interfaces;
using Fatec.Store.Orders.Application.v1.Services;
using Fatec.Store.Orders.Domain.v1.Interfaces;
using Fatec.Store.Orders.Infrastructure.CrossCutting.v1;
using Fatec.Store.Orders.Infrastructure.Data.v1.Context;
using Fatec.Store.Orders.Infrastructure.Data.v1.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

namespace Fatec.Store.Orders.Api.IoC
{
    public static class Bootstrapper
    {
        public static void InjectDependencies(this IServiceCollection services, WebApplicationBuilder builder) =>
                                services.AddConfigurations(builder)
                                        .InjectContext(builder.Configuration)
                                        .InjectRepositories()
                                        .InjectServices()
                                        .InjectMediator()
                                        .InjectAutoMapper()
                                        .InjectAuthenticationSwagger()
                                        .AddHttpContextAccessor()
                                        .ConfigureAuthentication(builder.Configuration);

        public static IServiceCollection AddConfigurations(this IServiceCollection services, WebApplicationBuilder builder)
        {
            services.Configure<AppsettingsConfigurations>(builder.Configuration.GetSection(nameof(AppsettingsConfigurations)));

            return services;
        }

        private static IServiceCollection InjectContext(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetAppSettings().Database;
            services.AddDbContext<OrdersDbContext>(options => options.UseSqlServer(connectionString));

            services.AddDbContext<OrdersDbContext>(options => options.UseSqlServer(connectionString));

            return services;
        }

        private static IServiceCollection InjectRepositories(this IServiceCollection services)
        {
            services.AddTransient<IOrdersRepository, OrdersRepository>();

            return services;
        }

        private static IServiceCollection InjectServices(this IServiceCollection services)
        {
            services.AddHttpClient<IViaCepService, ViaCepService>();

            return services;
        }

        private static IServiceCollection InjectMediator(this IServiceCollection services)
        {
            services.AddMediatR(config => config.RegisterServicesFromAssemblyContaining(typeof(CreateOrderCommand)));

            return services;
        }

        private static IServiceCollection InjectAutoMapper(this IServiceCollection services)
        {
            services.AddAutoMapper(cfg => cfg.AddMaps(typeof(CreateOrderCommandProfile).Assembly));

            return services;
        }

        private static IServiceCollection ConfigureAuthentication(this IServiceCollection services, IConfiguration configuration)
        {
            var jwtConfig = configuration.GetAppSettings().JwtConfiguration!;

            services.AddAuthentication(authOptions =>
            {
                authOptions.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                authOptions.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(jwtOptions =>
            {
                jwtOptions.RequireHttpsMetadata = false;
                jwtOptions.SaveToken = false;
                jwtOptions.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(jwtConfig.SecretJwtKey)),
                    ValidIssuer = jwtConfig.Issuer,
                    ValidAudience = jwtConfig.Audience,
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.Zero
                };
            });

            services.AddAuthorizationBuilder()
                .AddPolicy(nameof(AccessPoliciesEnum.Write),
                    policy => policy.RequireRole(jwtConfig.WriteRoles))
                .AddPolicy(nameof(AccessPoliciesEnum.Read),
                    policy => policy.RequireRole(jwtConfig.ReadRoles));

            return services;
        }

        private static IServiceCollection InjectAuthenticationSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Fatec.Store.Orders.Api",
                    Version = "v1",
                    Description = "Api responsável por gerenciar as vendas"
                });

                c.AddSecurityDefinition("bearer", new OpenApiSecurityScheme
                {
                    Description =
                        "JWT Authorization Header - Utilizado com Bearer Authentication.\r\n\r\n" +
                        "Digite seu token no campo abaixo.\r\n\r\n" +
                        "Exemplo (informar apenas o token): '12345abcdef'",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.Http,
                    Scheme = "bearer",
                    BearerFormat = "JWT"
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "bearer"
                            }
                        },
                        Array.Empty<string>()
                    }
                });
            });

            return services;
        }

        private static AppsettingsConfigurations GetAppSettings(this IConfiguration configuration) =>
            configuration.GetSection(nameof(AppsettingsConfigurations)).Get<AppsettingsConfigurations>()!;
    }
}