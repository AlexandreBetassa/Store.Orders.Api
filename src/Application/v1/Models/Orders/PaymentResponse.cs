namespace Fatec.Store.Orders.Application.v1.Models.Orders
{
    public class PaymentResponse
    {
        public string RegisterPaymentId { get; set; }

        public decimal TotalPaymentAmount { get; set; }

        public decimal TotalOriginalAmount { get; set; }

        public decimal TotalDiscount { get; set; }

        public string DiscountCouponCode { get; set; }

        public string FormOfPayment { get; set; }
    }
}