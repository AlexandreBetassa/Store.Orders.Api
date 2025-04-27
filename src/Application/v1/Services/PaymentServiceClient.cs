using Fatec.Store.Orders.Application.v1.Interfaces;
using Fatec.Store.Orders.Application.v1.Models.Payment.RegisterPayment;
using Fatec.Store.Orders.Infrastructure.CrossCutting.v1;
using Microsoft.Extensions.Options;

namespace Fatec.Store.Orders.Application.v1.Services
{
    public class PaymentServiceClient(HttpClient httpClient, IOptions<AppsettingsConfigurations> options) : IPaymentServiceClient
    {
        private readonly HttpClient _httpClient = httpClient;

        private readonly string _couponCepUrl = string.Empty;

        public async Task<RegisterPaymentResponse> RegisterPaymentAsync(RegisterPaymentRequest request)
        {
            return await Task.FromResult(new RegisterPaymentResponse());
        }
    }
}