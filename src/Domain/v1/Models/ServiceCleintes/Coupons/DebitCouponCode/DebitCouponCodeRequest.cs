namespace Fatec.Store.Orders.Domain.v1.Models.ServiceCleintes.Coupons.DebitCouponCode
{
    public class DebitCouponCodeRequest
    {
        public string CouponCode { get; set; }

        public int UserId { get; set; }
    }
}