using AutoMapper;
using Fatec.Store.Framework.Core.Bases.v1.CommandHandler;
using Fatec.Store.Orders.Application.v1.Shared.Extensions;
using Fatec.Store.Orders.Domain.v1.Interfaces.DomainServices;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Globalization;

namespace Fatec.Store.Orders.Application.v1.Commands.Payments.GeneratePixPayload
{
    public class GeneratePixPayloadCommandHandler : BaseCommandHandler<GeneratePixPayloadCommand, GeneratePixPayloadCommandResponse>
    {
        private readonly IPaymentDomainService _paymentDomainService;
        private readonly string _customerName;

        public GeneratePixPayloadCommandHandler(
            ILoggerFactory loggerFactory,
            IMapper mapper,
            IHttpContextAccessor httpContext,
            IPaymentDomainService paymentDomainService)
            : base(loggerFactory.CreateLogger<GeneratePixPayloadCommandHandler>(), mapper, httpContext)
        {
            _paymentDomainService = paymentDomainService;
            _customerName = httpContext.GetUserName();
        }

        public override async Task<GeneratePixPayloadCommandResponse> Handle(GeneratePixPayloadCommand request, CancellationToken cancellationToken)
        {
            var payload = _paymentDomainService.GeneratePixPayload(_customerName, request.Amount.ToString("0.00", CultureInfo.InvariantCulture));
            var qrCode = _paymentDomainService.GenerateQrCodeZXing(payload);
            return new()
            {
                PixPayload = payload,
                PixQrCode = $"data:image/png;base64,{Convert.ToBase64String(qrCode)}",
            };
        }
    }
}
