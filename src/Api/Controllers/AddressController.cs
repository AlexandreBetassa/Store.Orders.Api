using Fatec.Store.Framework.Core.Bases.v1.Controllers;
using Fatec.Store.Orders.Application.v1.Queries.DeliveryAddress.GetAddress;
using Fatec.Store.Orders.Domain.v1.Enum;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Fatec.Store.Orders.Api.Controllers
{
    [Route("api/v1/address")]
    [ApiController]
    public class AddressController(IMediator mediator) : BaseController<AddressController>(mediator)
    {
        [HttpGet("{zipCode}")]
        [Authorize(Policy = nameof(RolesUserEnum.User))]
        public async Task<IActionResult> GetAddressAsync([FromRoute] string zipCode) => 
            await ExecuteAsync(() => Mediator.Send(new GetAddressCommand(zipCode)), HttpStatusCode.OK);
    }
}