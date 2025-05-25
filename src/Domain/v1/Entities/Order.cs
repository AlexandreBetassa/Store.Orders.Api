using Fatec.Store.Framework.Core.Bases.v1.Entities;

namespace Fatec.Store.Orders.Domain.v1.Entities
{
    public class Order : BaseEntity
    {
        public int UserId { get; set; }

        public int? PaymentId { get; set; }

        public decimal TotalPayment { get; set; }

        public string? CouponCode { get; set; }

        public int AddressId { get; set; }

        public DateTime OrderDate { get; set; }

        public DeliveryAddress Address { get; set; }

        public int ContactId { get; set; }

        public Contact Contact { get; set; }

        public IEnumerable<Product> Products { get; set; }
    }
}