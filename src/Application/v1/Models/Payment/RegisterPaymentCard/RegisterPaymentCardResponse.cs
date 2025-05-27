namespace Fatec.Store.Orders.Application.v1.Models.Payment.RegisterPaymentCard
{
    public class RegisterPaymentCardResponse
    {
        public int PaymentId { get; set; } = new Random().Next(99999999);
    }
}
