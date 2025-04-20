namespace Fatec.Store.Orders.Application.v1.Models.Orders
{
    public abstract class OrderResponse
    {
        public int CustomerId { get; set; }

        public decimal TotalAmount { get; set; }

        public DateTime OrderDate { get; set; }

        public DeliveryAddressResponse Address { get; set; }

        public IEnumerable<FormOfPaymentResponse> FormOfPayments { get; set; }

        public ContactResponse Contact { get; set; }

        public IEnumerable<ProductResponse> Products { get; set; }
    }
}
