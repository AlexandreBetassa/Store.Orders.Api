namespace Fatec.Store.Orders.Application.v1.Models.Payment.RegisterPayment
{
    public class RegisterPaymentResponse
    {
        public Guid PaymentId { get; set; } = Guid.NewGuid();
    }
}