using Fatec.Store.Orders.Domain.v1.Enums;

namespace Fatec.Store.Orders.Domain.v1.Models
{
    public class FormOfPayment
    {
        public FormOfPaymentTypeEnum FormOfPaymentType { get; set; }

        public decimal TotalDiscount { get; set; }

        public decimal TotalAmount { get; set; }
    }
}
