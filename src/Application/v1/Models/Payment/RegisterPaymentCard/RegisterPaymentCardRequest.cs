using Fatec.Store.Orders.Domain.v1.Enum;

namespace Fatec.Store.Orders.Application.v1.Models.Payment.RegisterPaymentCard
{
    public class RegisterPaymentCardRequest
    {
        public FormOfPaymentEnum FormOfPayment { get; set; }

        public decimal Value { get; set; }

        public int Cvv { get; set; }

        public string CardNumber { get; set; }

        public string CardName { get; set; }

        public string Expiration { get; set; }

        public int Installments { get; set; }
    }
}
