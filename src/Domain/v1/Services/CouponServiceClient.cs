using Fatec.Store.Orders.Domain.v1.Interfaces.ServiceClients;
using Fatec.Store.Orders.Domain.v1.Models.ServiceCleintes.DebitCouponCode;
using Fatec.Store.Orders.Domain.v1.Models.ServiceCleintes.GetCoupon;
using Fatec.Store.Orders.Infrastructure.CrossCutting.v1;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http.Json;
using System.Text;

namespace Fatec.Store.Orders.Domain.v1.Services
{
    public class CouponServiceClient(HttpClient httpClient, IOptions<AppsettingsConfigurations> options) : ICouponServiceClient
    {
        private readonly HttpClient _httpClient = httpClient;

        private readonly string _couponCepUrl = options.Value.ServiceClients.Coupon;

        public async Task DebitCouponCodeAsync(DebitCouponCodeRequest debitCouponCodeRequest)
        {
            var content = new StringContent(
                JsonConvert.SerializeObject(debitCouponCodeRequest),
                Encoding.UTF8,
                "application/json");

            await _httpClient.PatchAsync($"{_couponCepUrl}", content);
        }

        public async Task<GetByCouponCodeResponse?> GetCouponByCouponCodeAsync(string couponCode)
        {
            var response = await _httpClient.GetAsync($"{_couponCepUrl}/{couponCode}");

            if (response.StatusCode.Equals(HttpStatusCode.NoContent)) return new();

            return await response?.Content?.ReadFromJsonAsync<GetByCouponCodeResponse>()!;
        }
    }
}
