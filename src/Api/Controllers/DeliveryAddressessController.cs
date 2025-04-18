using Fatec.Store.Framework.Core.Bases.v1.Controllers;
using Fatec.Store.Orders.Application.v1.Queries.DeliveryAddress.GetDeliveryAddress;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Fatec.Store.Orders.Api.Controllers
{
    [Route("api/v1/deliveryAddressess")]
    [ApiController]
    public class DeliveryAddressessController(IMediator mediator) : BaseController<DeliveryAddressessController>(mediator)
    {
        [HttpGet("{zipCode}")]
        //[Authorize(Policy = nameof(AccessPoliciesEnum.Write))]
        public async Task<IActionResult> CreateOrderAsync([FromRoute] string zipCode) =>
            await ExecuteAsync(() => Mediator.Send(new GetDeliveryAddressCommand(zipCode)), HttpStatusCode.OK);
    }
}
