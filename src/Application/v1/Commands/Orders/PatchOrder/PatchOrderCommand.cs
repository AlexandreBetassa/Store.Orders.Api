using MediatR;

namespace Fatec.Store.Orders.Application.v1.Commands.Orders.PatchOrder
{
    public class PatchOrderCommand(int orderId) : IRequest<Unit>
    {
        public int OrderId { get; set; } = orderId;
    }
}
