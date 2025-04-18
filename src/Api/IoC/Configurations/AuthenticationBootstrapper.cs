using Fatec.Store.Framework.Core.Enums;
using Fatec.Store.Orders.Infrastructure.CrossCutting.v1.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

namespace Fatec.Store.Orders.Api.IoC.Configurations
{
    public static class AuthenticationBootstrapper
    {
        public static IServiceCollection ConfigureAuthentication(this IServiceCollection services, IConfiguration configuration)
        {
            var jwtConfig = configuration.GetAppSettings().JwtConfiguration!;

            services
                .ConfigureAuthenticationBuilder(jwtConfig)
                .AddAuthentication(authOptions =>
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

            return services;
        }

        private static IServiceCollection ConfigureAuthenticationBuilder(this IServiceCollection services, JwtConfiguration jwtConfig)
        {
            services.AddAuthorizationBuilder()
                .AddPolicy(nameof(AccessPoliciesEnum.Write),
                    policy => policy.RequireRole(jwtConfig.WriteRoles))
                .AddPolicy(nameof(AccessPoliciesEnum.Read),
                    policy => policy.RequireRole(jwtConfig.ReadRoles));

            return services;
        }

        public static IServiceCollection InjectAuthenticationSwagger(this IServiceCollection services)
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
    }
}