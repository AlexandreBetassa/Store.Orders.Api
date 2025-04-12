using Fatec.Store.Orders.Application.v1.Commands.CreateOrder.Models;
using MediatR;

namespace Fatec.Store.Orders.Application.v1.Commands.CreateOrder
{
    public class CreateOrderCommand : IRequest<Unit>
    {
        public int CustomerId { get; set; }

        public decimal TotalAmount { get; set; }

        public decimal TotalDiscount { get; set; }

        public DateTime OrderDate { get; set; }

        public int AddressId { get; set; }

        public DeliveryAddressCommand Address { get; set; }

        public IEnumerable<FormOfPaymentCommand> FormOfPayments { get; set; }

        public int ContactId { get; set; }

        public ContactCommand Contact { get; set; }

        public IEnumerable<ProductCommand> Products { get; set; }

    }
}
