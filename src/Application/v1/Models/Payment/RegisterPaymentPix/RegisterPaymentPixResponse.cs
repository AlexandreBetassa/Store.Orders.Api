namespace Fatec.Store.Orders.Application.v1.Models.Payment.RegisterPaymentPix
{
    public class RegisterPaymentPixResponse
    {
        public int PaymentId { get; set; } = new Random().Next(99999999);
    }
}