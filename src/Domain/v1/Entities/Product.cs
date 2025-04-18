using Fatec.Store.Framework.Core.Bases.v1.Entities;

namespace Fatec.Store.Orders.Domain.v1.Entities
{
    public class Product : BaseEntity
    {
        public int ProductId { get; set; }

        public decimal Amount { get; set; }

        public int Quantity { get; set; }

        public int OrderId { get; set; }

        public Order Order { get; set; }
    }
}
