using Fatec.Store.Orders.Domain.v1.Interfaces.ServiceClients;
using Fatec.Store.Orders.Domain.v1.Models.ServiceCleintes.GetCoupon;
using Fatec.Store.Orders.Infrastructure.CrossCutting.v1;
using Microsoft.Extensions.Options;
using System.Net;
using System.Net.Http.Json;

namespace Fatec.Store.Orders.Domain.v1.Services
{
    public class CouponServiceClient(HttpClient httpClient, IOptions<AppsettingsConfigurations> options) : ICouponServiceClient
    {
        private readonly HttpClient _httpClient = httpClient;

        private readonly string _couponCepUrl = options.Value.ServiceClients.Coupon;

        public Task DebitQuantityCouponCodeAsync(string couponCode, string userId)
        {
            throw new NotImplementedException();
        }

        public async Task<GetByCouponCodeResponse?> GetCouponByCouponCodeAsync(string couponCode)
        {
            var response = await _httpClient.GetAsync($"{_couponCepUrl}/{couponCode}");

            if (response.StatusCode.Equals(HttpStatusCode.NoContent)) return new();

            return await response?.Content?.ReadFromJsonAsync<GetByCouponCodeResponse>()!;
        }
    }
}
