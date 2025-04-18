using Fatec.Store.Framework.Core.Bases.v1.Controllers;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Fatec.Store.Orders.Api.Controllers
{
    [Route("api/v1/deliveryAddressess")]
    [ApiController]
    public class DeliveryAddressessController(IMediator mediator) : BaseController<DeliveryAddressessController>(mediator)
    {
    }
}
