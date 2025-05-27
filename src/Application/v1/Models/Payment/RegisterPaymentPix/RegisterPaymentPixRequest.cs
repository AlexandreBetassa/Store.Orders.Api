using Fatec.Store.Orders.Domain.v1.Enum;

namespace Fatec.Store.Orders.Application.v1.Models.Payment.RegisterPaymentPix
{
    public class RegisterPaymentPixRequest
    {
        public FormOfPaymentEnum FormOfPayment { get; set; }

        public decimal Value { get; set; }
    }
}
