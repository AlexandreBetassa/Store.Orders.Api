using MediatR;

namespace Fatec.Store.Orders.Application.v1.Queries.DeliveryAddress.GetDeliveryAddress
{
    public class GetDeliveryAddressCommand : IRequest<GetDeliveryAddressCommandResponse>
    {
        public string ZipCode { get; set; }
    }
}