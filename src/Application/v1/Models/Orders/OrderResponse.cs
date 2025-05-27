namespace Fatec.Store.Orders.Application.v1.Models.Orders
{
    public abstract class OrderResponse
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public bool Status { get; set; }

        public DateTime OrderDate { get; set; }

        public DeliveryAddressResponse Address { get; set; }

        public int PaymentId { get; set; }

        public string CouponCode { get; set; }

        public decimal TotalPayment { get; set; }

        public ContactResponse Contact { get; set; }

        public IEnumerable<ProductResponse> Products { get; set; }
    }
}
