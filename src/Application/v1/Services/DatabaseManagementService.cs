using Fatec.Store.Orders.Infrastructure.Data.v1.Context;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Fatec.Store.Orders.Application.v1.Services
{
    public static class DatabaseManagementService
    {
        public static void MigrationInitialisation(IApplicationBuilder app)
        {
            using var serviceScope = app.ApplicationServices.CreateScope();
            serviceScope?.ServiceProvider?.GetService<OrdersDbContext>()?.Database?.Migrate();
        }
    }
}
