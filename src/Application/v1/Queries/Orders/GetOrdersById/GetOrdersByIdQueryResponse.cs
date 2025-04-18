using Fatec.Store.Orders.Application.v1.Models.Orders;

namespace Fatec.Store.Orders.Application.v1.Queries.Orders.GetOrdersById
{
    public class GetOrdersByIdQueryResponse
    {
        public int CustomerId { get; set; }

        public decimal TotalAmount { get; set; }

        public decimal TotalDiscount { get; set; }

        public DateTime OrderDate { get; set; }

        public DeliveryAddressResponse Address { get; set; }

        public IEnumerable<FormOfPaymentResponse> FormOfPayments { get; set; }

        public ContactResponse Contact { get; set; }

        public IEnumerable<ProductResponse> Products { get; set; }
    }
}