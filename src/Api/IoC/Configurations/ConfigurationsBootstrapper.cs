using Fatec.Store.Orders.Infrastructure.CrossCutting.v1;

namespace Fatec.Store.Orders.Api.IoC.Configurations
{
    public static class ConfigurationsBootstrapper
    {
        public static IServiceCollection AddConfigurations(this IServiceCollection services, WebApplicationBuilder builder)
        {
            services.Configure<AppsettingsConfigurations>(builder.Configuration.GetSection(nameof(AppsettingsConfigurations)));

            return services;
        }

        public static AppsettingsConfigurations GetAppSettings(this IConfiguration configuration) =>
            configuration.GetSection(nameof(AppsettingsConfigurations)).Get<AppsettingsConfigurations>()!;
    }
}
