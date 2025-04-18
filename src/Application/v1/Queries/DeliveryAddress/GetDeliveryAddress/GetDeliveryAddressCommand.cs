using MediatR;

namespace Fatec.Store.Orders.Application.v1.Queries.DeliveryAddress.GetDeliveryAddress
{
    public class GetDeliveryAddressCommand(string zipCode) : IRequest<GetDeliveryAddressCommandResponse>
    {
        public string ZipCode { get; set; } = zipCode;
    }
}