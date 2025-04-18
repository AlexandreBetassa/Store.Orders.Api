using Fatec.Store.Framework.Core.Bases.v1.Repository;
using Fatec.Store.Orders.Domain.v1.Entities;
using Fatec.Store.Orders.Domain.v1.Interfaces;
using Fatec.Store.Orders.Infrastructure.Data.v1.Context;
using Microsoft.EntityFrameworkCore;

namespace Fatec.Store.Orders.Infrastructure.Data.v1.Repositories
{
    public class OrdersRepository(OrdersDbContext context) : BaseRepository<Order>(context), IOrdersRepository
    {
        public async Task<IEnumerable<Order>> GetOrdersByCustomerIdAsync(int customerId)
        {
            return await Context.Set<Order>()
                .AsNoTracking()
                .Include(order => order.FormOfPayments)
                .Include(order => order.Products)
                .Include(order => order.Address)
                .Include(order => order.Contact)
                .Where(order => order.CustomerId.Equals(customerId))
                .ToListAsync();
        }
    }
}