using Fatec.Store.Framework.Core.Bases.v1.Controllers;
using Fatec.Store.Orders.Application.v1.Commands.Payments.GeneratePixPayload;
using Fatec.Store.Orders.Application.v1.Commands.Payments.RegisterPaymentCard;
using Fatec.Store.Orders.Application.v1.Commands.Payments.RegisterPaymentPix;
using Fatec.Store.Orders.Application.v1.Queries.Payments.GetFormsOfPayment;
using Fatec.Store.Orders.Domain.v1.Enum;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Fatec.Store.Orders.Api.Controllers
{
    [Route("api/v1/payments")]
    [ApiController]
    public class PaymentsController(IMediator mediator) : BaseController<PaymentsController>(mediator)
    {
        [HttpGet]
        [Authorize(Policy = nameof(RolesUserEnum.User))]
        public async Task<IActionResult> GetFormsOfPayments() =>
             await ExecuteAsync(() => Mediator.Send(new GetFormsOfPaymentQuery()), HttpStatusCode.OK);

        [HttpPost("pix/payload")]
        [Authorize(Policy = nameof(RolesUserEnum.User))]
        public async Task<IActionResult> GeneratePixPayload([FromBody] GeneratePixPayloadCommand request) =>
                await ExecuteAsync(() => Mediator.Send(request), HttpStatusCode.OK);

        [HttpPost("pix")]
        [Authorize(Policy = nameof(RolesUserEnum.User))]
        public async Task<IActionResult> RegisterPaymentPixAsync([FromBody] RegisterPaymentPixCommand request) =>
            await ExecuteAsync(() => Mediator.Send(request), HttpStatusCode.OK);

        [HttpPost("card")]
        [Authorize(Policy = nameof(RolesUserEnum.User))]
        public async Task<IActionResult> RegisterPaymentCardAsync([FromBody] RegisterPaymentCardCommand request) =>
            await ExecuteAsync(() => Mediator.Send(request), HttpStatusCode.OK);
    }
}
