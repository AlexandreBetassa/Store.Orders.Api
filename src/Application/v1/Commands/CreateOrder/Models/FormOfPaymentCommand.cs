using Fatec.Store.Orders.Domain.v1.Enums;

namespace Fatec.Store.Orders.Application.v1.Commands.CreateOrder.Models
{
    public class FormOfPaymentCommand
    {
        public FormOfPaymentTypeEnum FormOfPaymentType { get; set; }

        public decimal Discount { get; set; }

        public decimal Amount { get; set; }
    }
}