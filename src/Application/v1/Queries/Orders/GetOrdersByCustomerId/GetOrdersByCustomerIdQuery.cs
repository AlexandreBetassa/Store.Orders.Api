using MediatR;

namespace Fatec.Store.Orders.Application.v1.Queries.Orders.GetOrdersByCustomerId
{
    public class GetOrdersByCustomerIdQuery(string customerId) : IRequest<IEnumerable<GetOrdersByCustomerIdQueryResponse>>
    {
        public int CustomerId { get; set; } = int.Parse(customerId);
    }
}
