using Fatec.Store.Orders.Domain.v1.Enums;

namespace Fatec.Store.Orders.Application.v1.Models.Orders
{
    public class FormOfPaymentResponse
    {
        public FormOfPaymentTypeEnum FormOfPaymentType { get; set; }

        public decimal TotalAmount { get; set; }
    }
}