using MediatR;

namespace Fatec.Store.Orders.Application.v1.Queries.Orders.GetOrdersById
{
    public class GetOrdersByIdQuery(string orderId) : IRequest<GetOrdersByIdQueryResponse>
    {
        public int OrderId { get; set; } = int.Parse(orderId);
    }
}