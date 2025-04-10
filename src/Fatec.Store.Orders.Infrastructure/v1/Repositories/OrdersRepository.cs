using Fatec.Store.Orders.Domain.v1.Entities;
using Fatec.Store.Orders.Domain.v1.Interfaces;
using Microsoft.EntityFrameworkCore;
using Store.Framework.Core.Bases.v1.Repository;

namespace Fatec.Store.Orders.Infrastructure.Data.v1.Repositories
{
    public class OrdersRepository(DbContext context) 
        : BaseRepository<Order>(context), IOrdersRepository
    {
    }
}