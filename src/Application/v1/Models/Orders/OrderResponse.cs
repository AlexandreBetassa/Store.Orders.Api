namespace Fatec.Store.Orders.Application.v1.Models.Orders
{
    public abstract class OrderResponse
    {
        public int UserId { get; set; }

        public bool Status { get; set; }

        public DateTime OrderDate { get; set; }

        public DeliveryAddressResponse Address { get; set; }

        public PaymentResponse Payment { get; set; }

        public ContactResponse Contact { get; set; }

        public IEnumerable<ProductResponse> Products { get; set; }

        public void CalculatePaymentsAmount()
        {
            Payment.TotalOriginalAmount = Products.Sum(p => p.Price * p.Quantity);
            Payment.TotalPaymentAmount = Payment.TotalOriginalAmount - Payment.TotalDiscount;
        }
    }
}
