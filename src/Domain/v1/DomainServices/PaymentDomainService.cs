using Fatec.Store.Orders.Domain.v1.Interfaces.ServiceClients;
using Fatec.Store.Orders.Domain.v1.Interfaces.Services;

namespace Fatec.Store.Orders.Domain.v1.DomainServices
{
    public class PaymentDomainService(ICouponServiceClient couponServiceClient) : IPaymentDomainService
    {
        private readonly ICouponServiceClient _couponServiceClient = couponServiceClient;

        public async Task<decimal> CalculateDiscountAsync(decimal originalAmount, string couponCode)
        {
            var couponResponse = await _couponServiceClient.GetCouponByCouponCodeAsync(couponCode);

            if (couponResponse.Active)
                return Convert.ToDecimal(couponResponse.Discount) / 100 * originalAmount;

            return decimal.Zero;
        }

        public async Task DebitQuantityCouponCodeAsync(string couponCode, string userId) =>
            await _couponServiceClient.DebitQuantityCouponCodeAsync(couponCode, userId);
    }
}