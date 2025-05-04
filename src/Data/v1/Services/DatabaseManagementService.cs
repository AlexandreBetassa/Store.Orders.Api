using Fatec.Store.Orders.Infrastructure.Data.v1.Context;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Fatec.Store.Orders.Infrastructure.Data.v1.Services
{
    public static class DatabaseManagementService
    {
        public static void MigrationInitialisation(IApplicationBuilder app)
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
