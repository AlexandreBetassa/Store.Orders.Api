using Fatec.Store.Orders.Domain.v1.Interfaces.ServiceClients;
using Fatec.Store.Orders.Domain.v1.Interfaces.Services;
using Microsoft.Extensions.Logging;

namespace Fatec.Store.Orders.Domain.v1.DomainServices
{
    public class PaymentDomainService(ICouponServiceClient couponServiceClient, ILoggerFactory loggerFactory) : IPaymentDomainService
    {
        private readonly ICouponServiceClient _couponServiceClient = couponServiceClient;
        private readonly ILogger<PaymentDomainService> _logger = loggerFactory.CreateLogger<PaymentDomainService>();

        public async Task<decimal> CalculateDiscountAsync(decimal originalAmount, string couponCode)
        {
            var couponResponse = await _couponServiceClient.GetCouponByCouponCodeAsync(couponCode);

            if (couponResponse.Active)
                return Convert.ToDecimal(couponResponse.Discount) / 100 * originalAmount;

            return decimal.Zero;
        }

        public async Task DebitCouponCodeAsync(string couponCode, int userId)
        {
            try
            {
                await _couponServiceClient.DebitCouponCodeAsync(new() { CouponCode = couponCode, UserId = userId });
            }
            catch (Exception ex)
            {
                _logger.LogWarning(ex, "{Service}.{Method}", nameof(PaymentDomainService), nameof(DebitCouponCodeAsync));
            }
        }
    }
}