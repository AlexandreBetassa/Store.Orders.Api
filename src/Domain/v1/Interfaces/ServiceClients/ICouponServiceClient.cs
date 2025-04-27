using Fatec.Store.Orders.Domain.v1.Models.ServiceCleintes.Coupons.DebitCouponCode;
using Fatec.Store.Orders.Domain.v1.Models.ServiceCleintes.Coupons.GetCoupon;

namespace Fatec.Store.Orders.Domain.v1.Interfaces.ServiceClients
{
    public interface ICouponServiceClient
    {
        Task<GetByCouponCodeResponse> GetCouponByCouponCodeAsync(string couponCode);

        Task DebitCouponCodeAsync(DebitCouponCodeRequest debitCouponCodeRequest);
    }
}
