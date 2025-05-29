using Fatec.Store.Framework.Core.Bases.v1.Controllers;
using Fatec.Store.Orders.Application.v1.Commands.Orders.CreateOrder;
using Fatec.Store.Orders.Application.v1.Commands.Orders.PatchOrder;
using Fatec.Store.Orders.Application.v1.Queries.Orders.GetOrdersByCustomerId;
using Fatec.Store.Orders.Application.v1.Queries.Orders.GetOrdersById;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Fatec.Store.Orders.Api.Controllers
{
    [Route("api/v1/order")]
    [ApiController]
    public class OrdersController(IMediator mediator) : BaseController<OrdersController>(mediator)
    {
        [HttpPost]
        //[Authorize(Policy = "User")]
        public async Task<IActionResult> CreateOrderAsync([FromBody] CreateOrderCommand request) =>
            await ExecuteAsync(() => Mediator.Send(request), HttpStatusCode.Created);

        [HttpGet("{orderId}")]
        //[Authorize(Policy = nameof(AccessPoliciesEnum.Write))]
        public async Task<IActionResult> GetOrderByIdAsync([FromRoute] string orderId) =>
            await ExecuteAsync(() => Mediator.Send(new GetOrdersByIdQuery(orderId)), HttpStatusCode.OK);

        [HttpGet("customer/{customerId}")]
        //[Authorize(Policy = nameof(AccessPoliciesEnum.Write))]
        public async Task<IActionResult> GetOrderByCustomerIdAsync([FromRoute] string customerId) =>
            await ExecuteAsync(() => Mediator.Send(new GetOrdersByCustomerIdQuery(customerId)), HttpStatusCode.OK);

        [HttpPatch("{orderId}")]
        //[Authorize(Policy = nameof(AccessPoliciesEnum.Write))]
        public async Task<IActionResult> PatchStatusOrderByOrderIdAsync([FromRoute] int orderId) =>
            await ExecuteAsync(() => Mediator.Send(new PatchOrderCommand(orderId)), HttpStatusCode.OK);
    }
}