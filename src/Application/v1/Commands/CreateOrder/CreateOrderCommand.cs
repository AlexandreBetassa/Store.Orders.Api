using MediatR;

namespace Fatec.Store.Orders.Application.v1.Commands.CreateOrder
{
    public class CreateOrderCommand : IRequest<Unit>
    {
        public IEnumerable<int> ProductsIds { get; set; }

        public int PersonId { get; set; }

    }
}
