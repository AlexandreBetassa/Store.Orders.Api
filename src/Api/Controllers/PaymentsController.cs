using Fatec.Store.Framework.Core.Bases.v1.Controllers;
using Fatec.Store.Orders.Application.v1.Commands.Payments.CreatePayment;
using Fatec.Store.Orders.Application.v1.Commands.Payments.GeneratePixPayload;
using Fatec.Store.Orders.Application.v1.Queries.Payments.GetFormsOfPayment;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Fatec.Store.Orders.Api.Controllers
{
    [Route("api/v1/payments")]
    [ApiController]
    public class PaymentsController(IMediator mediator) : BaseController<PaymentsController>(mediator)
    {
        [HttpGet]
        public async Task<IActionResult> GetFormsOfPayments() =>
             await ExecuteAsync(() => Mediator.Send(new GetFormsOfPaymentQuery()), HttpStatusCode.OK);

        [HttpPost("pix/payload")]
        public async Task<IActionResult> GeneratePixPayload([FromBody] GeneratePixPayloadCommand request) =>
                await ExecuteAsync(() => Mediator.Send(request), HttpStatusCode.OK);

        [HttpPost]
        public async Task<IActionResult> RegisterPaymentAsync([FromBody] RegisterPaymentCommand request) =>
            await ExecuteAsync(() => Mediator.Send(request), HttpStatusCode.OK);
    }
}
