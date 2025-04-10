using Fatec.Store.Orders.Domain.v1.Entities;
using Store.Framework.Core.Bases.v1.Interfaces;

namespace Fatec.Store.Orders.Domain.v1.Interfaces
{
    public interface IOrdersRepository : IRepository<Order>
    {
    }
}