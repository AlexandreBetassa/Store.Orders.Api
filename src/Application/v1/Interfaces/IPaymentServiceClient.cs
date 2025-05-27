using Fatec.Store.Orders.Application.v1.Models.Payment.RegisterPaymentCard;
using Fatec.Store.Orders.Application.v1.Models.Payment.RegisterPaymentPix;

namespace Fatec.Store.Orders.Application.v1.Interfaces
{
    public interface IPaymentServiceClient
    {
        Task<RegisterPaymentPixResponse> RegisterPaymentPixAsync(RegisterPaymentPixRequest request); 

        Task<RegisterPaymentCardResponse> RegisterPaymentCardAsync(RegisterPaymentCardRequest request);
    }
}
