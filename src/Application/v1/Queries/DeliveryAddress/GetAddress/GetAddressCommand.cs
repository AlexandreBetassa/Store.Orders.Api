using MediatR;

namespace Fatec.Store.Orders.Application.v1.Queries.DeliveryAddress.GetAddress
{
    public class GetAddressCommand(string zipCode) : IRequest<GetAddressCommandResponse>
    {
        public string ZipCode { get; set; } = zipCode;
    }
}