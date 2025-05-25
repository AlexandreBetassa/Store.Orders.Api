namespace Fatec.Store.Orders.Domain.v1.Interfaces.DomainServices
{
    public interface IPaymentDomainService
    {
        Task<decimal> CalculateDiscountAsync(decimal originalAmount, string couponCode);

        Task DebitCouponCodeAsync(string couponCode, int userId);

        string GeneratePixPayload(string customerName, string amount);

        byte[] GenerateQrCodeZXing(string payload);
    }
}