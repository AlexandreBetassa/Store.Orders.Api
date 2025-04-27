namespace Fatec.Store.Orders.Application.v1.Models.Payment.RegisterPayment
{
    public class RegisterPaymentRequest
    {
        public string PaymentType { get; set; }

        public decimal Value { get; set; }
    }
}
