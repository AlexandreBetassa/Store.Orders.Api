namespace Fatec.Store.Orders.Domain.v1.Interfaces.Services
{
    public interface IPaymentDomainService
    {
        Task<decimal> CalculateDiscountAsync(decimal originalAmount, string couponCode);

        Task DebitQuantityCouponCodeAsync(string couponCode, string userId);
    }
}