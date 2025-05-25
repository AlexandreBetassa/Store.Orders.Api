namespace Fatec.Store.Orders.Application.v1.Models.Payment.RegisterPayment
{
    public class RegisterPaymentRequest
    {
        public string PaymentType { get; set; }

        public decimal Value { get; set; }

        public RegisterPaymentCardRequest CardInformations { get; set; }
    }

    public class RegisterPaymentCardRequest
    {
        public int Cvv { get; set; }

        public string CardNumber { get; set; }

        public string CardName { get; set; }

        public string Expiration { get; set; }
    }
}
