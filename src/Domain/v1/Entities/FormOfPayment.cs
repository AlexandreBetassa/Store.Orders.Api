using Fatec.Store.Framework.Core.Bases.v1.Entities;
using Fatec.Store.Orders.Domain.v1.Enums;

namespace Fatec.Store.Orders.Domain.v1.Entities
{
    public class FormOfPayment : BaseEntity
    {
        public int OrderId { get; set; }

        public Order Order { get; set; }

        public FormOfPaymentTypeEnum FormOfPaymentType { get; set; }

        public decimal TotalDiscount { get; set; }

        public decimal TotalAmount { get; set; }
    }
}
