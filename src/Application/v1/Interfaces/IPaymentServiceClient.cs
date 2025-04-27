using Fatec.Store.Orders.Application.v1.Models.Payment.RegisterPayment;

namespace Fatec.Store.Orders.Application.v1.Interfaces
{
    public interface IPaymentServiceClient
    {
        Task<RegisterPaymentResponse> RegisterPaymentAsync(RegisterPaymentRequest request); 
    }
}
