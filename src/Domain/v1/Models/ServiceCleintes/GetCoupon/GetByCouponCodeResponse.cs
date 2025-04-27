using System.Text.Json.Serialization;

namespace Fatec.Store.Orders.Domain.v1.Models.ServiceCleintes.GetCoupon
{
    public class GetByCouponCodeResponse
    {
        [JsonPropertyName("couponCode")]
        public string CouponCode { get; set; }

        [JsonPropertyName("active")]
        public bool Active { get; set; }

        [JsonPropertyName("quantity")]
        public int Quantity { get; set; }

        [JsonPropertyName("discount")]
        public double Discount { get; set; }
    }
}