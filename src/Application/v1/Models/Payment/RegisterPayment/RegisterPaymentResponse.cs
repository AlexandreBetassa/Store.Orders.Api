namespace Fatec.Store.Orders.Application.v1.Models.Payment.RegisterPayment
{
    public class RegisterPaymentResponse
    {
        public int PaymentId { get; set; } = new Random().Next(99999999);
    }
}