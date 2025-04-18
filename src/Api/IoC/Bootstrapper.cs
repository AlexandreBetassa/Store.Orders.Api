using Fatec.Store.Orders.Api.IoC.Configurations;
using Fatec.Store.Orders.Application.v1.Commands.Orders.CreateOrder;
using Fatec.Store.Orders.Application.v1.Interfaces;
using Fatec.Store.Orders.Application.v1.Services;
using Fatec.Store.Orders.Domain.v1.Interfaces;
using Fatec.Store.Orders.Infrastructure.Data.v1.Context;
using Fatec.Store.Orders.Infrastructure.Data.v1.Repositories;
using Microsoft.EntityFrameworkCore;

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

        private static IServiceCollection InjectContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<OrdersDbContext>(options => options.UseSqlServer(configuration.GetAppSettings().Database));

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
    }
}