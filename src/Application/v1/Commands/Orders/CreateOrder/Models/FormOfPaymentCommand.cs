using Fatec.Store.Orders.Domain.v1.Enums;

namespace Fatec.Store.Orders.Application.v1.Commands.Orders.CreateOrder.Models
{
    public class FormOfPaymentCommand
    {
        public FormOfPaymentTypeEnum FormOfPaymentType { get; set; }

        public decimal Amount { get; set; }
    }
}