using Fatec.Store.Orders.Application.v1.Interfaces;
using Fatec.Store.Orders.Application.v1.Models.Payment.RegisterPaymentCard;
using Fatec.Store.Orders.Application.v1.Models.Payment.RegisterPaymentPix;

namespace Fatec.Store.Orders.Application.v1.Services
{
    public class PaymentServiceClient(HttpClient client) : IPaymentServiceClient
    {
        public async Task<RegisterPaymentCardResponse> RegisterPaymentCardAsync(RegisterPaymentCardRequest request) =>
             await Task.FromResult(new RegisterPaymentCardResponse());

        public async Task<RegisterPaymentPixResponse> RegisterPaymentPixAsync(RegisterPaymentPixRequest request) =>
             await Task.FromResult(new RegisterPaymentPixResponse());
    }
}