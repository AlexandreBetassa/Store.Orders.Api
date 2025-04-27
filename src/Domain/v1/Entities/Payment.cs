using Fatec.Store.Framework.Core.Bases.v1.Entities;
using Fatec.Store.Orders.Domain.v1.Enums;

namespace Fatec.Store.Orders.Domain.v1.Entities
{
    public class Payment : BaseEntity
    {
        public string RegisterPaymentId { get; set; }

        public string DiscountCouponCode { get; set; }

        public FormOfPaymentTypeEnum FormOfPaymentType { get; set; }

        public decimal TotalOriginalAmount { get; set; }

        public decimal TotalDiscount { get; set; }
    }
}