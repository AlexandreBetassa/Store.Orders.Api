using Fatec.Store.Framework.Core.Bases.v1.Entities;

namespace Fatec.Store.Orders.Domain.v1.Entities
{
    public class Payment : BaseEntity
    {
        public int RegisterPaymentId { get; set; }

        public string DiscountCouponCode { get; set; }

        public string FormOfPayment { get; set; }

        public decimal TotalOriginalAmount { get; set; }

        public decimal TotalDiscount { get; set; }
    }
}