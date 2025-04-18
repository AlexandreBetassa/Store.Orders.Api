using Fatec.Store.Orders.Application.v1.Commands.Orders.CreateOrder.Models;
using MediatR;

namespace Fatec.Store.Orders.Application.v1.Commands.Orders.CreateOrder
{
    public class CreateOrderCommand : IRequest<Unit>
    {
        public int CustomerId { get; set; }

        public DateTime OrderDate { get; set; }

        public DeliveryAddressCommand Address { get; set; }

        public IEnumerable<FormOfPaymentCommand> FormOfPayments { get; set; }

        public ContactCommand Contact { get; set; }

        public IEnumerable<ProductCommand> Products { get; set; }

    }
}
