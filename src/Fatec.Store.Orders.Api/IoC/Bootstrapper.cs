using Fatec.Store.Orders.Domain.v1.Interfaces;
using Fatec.Store.Orders.Infrastructure.CrossCutting.v1;
using Fatec.Store.Orders.Infrastructure.Data.v1.Context;
using Fatec.Store.Orders.Infrastructure.Data.v1.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Store.Framework.Core.Enums;
using System.Text;

namespace Fatec.Store.Orders.Api.IoC
{
    public static class Bootstrapper
    {
        public static void InjectDependencies(this IServiceCollection services, WebApplicationBuilder builder)
        {
            var appSettingsConfigurations = services.AddConfigurations(builder);

            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();

            services.InjectAuthenticationSwagger();
            services.InjectContext(appSettingsConfigurations);
            services.InjectRepositories();
            services.InjectMediator();
            services.InjectAutoMapper();
            services.AddHttpContextAccessor();
            services.ConfigureAuthentication(appSettingsConfigurations);
        }

        private static void InjectAutoMapper(this IServiceCollection services)
        {
            //services.AddAutoMapper(opt => opt.AddMaps(typeof(CreateUserCommand).Assembly));
        }

        private static void InjectMediator(this IServiceCollection services)
        {
            //services.AddMediatR(new MediatRServiceConfiguration().RegisterServicesFromAssemblyContaining(typeof(GenerateTokenCommandHandler)));
        }

        private static void InjectRepositories(this IServiceCollection services)
        {
            services.AddScoped<IOrdersRepository, OrdersRepository>();
        }

        private static void InjectContext(this IServiceCollection services, AppsettingsConfigurations appSettingsConfigurations) =>
            services.AddDbContext<OrdersDbContext>(options => options.UseSqlServer(appSettingsConfigurations!.Database));

        //TODO: passar para framework
        private static void ConfigureAuthentication(this IServiceCollection services, AppsettingsConfigurations appSettingsConfigurations)
        {
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
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(appSettingsConfigurations.JwtConfiguration!.SecretJwtKey)),
                    ValidIssuer = appSettingsConfigurations.JwtConfiguration.Issuer,
                    ValidAudience = appSettingsConfigurations.JwtConfiguration.Audience,
                    ValidateIssuer = true,
                    ValidateAudience = true
                };
            });

            services.AddAuthorizationBuilder()
              .AddPolicy(nameof(AccessPoliciesEnum.Write),
                policy => policy.RequireRole(appSettingsConfigurations.JwtConfiguration!.WriteRoles))
             .AddPolicy(nameof(AccessPoliciesEnum.Read),
                policy => policy.RequireRole(appSettingsConfigurations.JwtConfiguration!.ReadRoles));
        }

        public static void InjectAuthenticationSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Fatec.Store.Orders.Api", Version = "v1", Description = "Api responsável por gerenciar as vendas" });

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
        }

        public static AppsettingsConfigurations? AddConfigurations(this IServiceCollection services, WebApplicationBuilder builder)
        {
            services.Configure<AppsettingsConfigurations>(builder.Configuration.GetSection(nameof(AppsettingsConfigurations)));
            services.AddTransient(sp => sp.GetRequiredService<IOptions<AppsettingsConfigurations>>().Value);

            return services?.BuildServiceProvider()?.GetRequiredService<AppsettingsConfigurations>();
        }
    }
}