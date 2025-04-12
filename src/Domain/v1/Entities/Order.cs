using Fatec.Store.Framework.Core.Bases.v1.Entities;
using Fatec.Store.Orders.Domain.v1.Models;

namespace Fatec.Store.Orders.Domain.v1.Entities
{
    public class Order : BaseEntity
    {
        public int CustomerId { get; set; }

        public decimal TotalAmount { get; set; }

        public decimal TotalDiscount { get; set; }

        public DateTime OrderDate { get; set; }

        public int AddressId { get; set; }

        public DeliveryAddress Address { get; set; }

        public int FormOfPaymentId { get; set; }

        public FormOfPayment FormOfPayment { get; set; }

        public int ContactId { get; set; }

        public Contact Contact { get; set; }

        public IEnumerable<Product> Products { get; set; }
    }
}