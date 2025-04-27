using Fatec.Store.Orders.Domain.v1.Enums;

namespace Fatec.Store.Orders.Application.v1.Commands.Orders.CreateOrder.Models
{
    public class PaymentCommand
    {
        public string DiscountCouponCode { get; set; }

        public FormOfPaymentTypeEnum FormOfPaymentType { get; set; }
    }
}