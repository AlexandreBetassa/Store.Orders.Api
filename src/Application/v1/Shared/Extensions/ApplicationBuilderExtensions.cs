using Fatec.Store.Orders.Infrastructure.Data.v1.Context;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Fatec.Store.Orders.Application.v1.Shared.Extensions
{
    public static class ApplicationBuilderExtensions
    {
        public static void MigrationInitialisation(this IApplicationBuilder app)
        {
            try
            {
                using var serviceScope = app.ApplicationServices.CreateScope();
                serviceScope?.ServiceProvider?.GetService<OrdersDbContext>()?.Database?.Migrate();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}
