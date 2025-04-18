using Fatec.Store.Framework.Core.Bases.v1.Repository;
using Fatec.Store.Orders.Domain.v1.Entities;
using Fatec.Store.Orders.Domain.v1.Interfaces;
using Fatec.Store.Orders.Infrastructure.Data.v1.Context;

namespace Fatec.Store.Orders.Infrastructure.Data.v1.Repositories
{
    public class OrdersRepository(OrdersDbContext context) : BaseRepository<Order>(context), IOrdersRepository
    {
    }
}