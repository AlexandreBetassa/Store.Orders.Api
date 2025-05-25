using AutoMapper;
using Fatec.Store.Framework.Core.Bases.v1.CommandHandler;
using Fatec.Store.Orders.Application.v1.Commands.Orders.CreateOrder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace Fatec.Store.Orders.Application.v1.Commands.Payments.CreatePayment
{
    public class CreatePaymentCommandHandler : BaseCommandHandler<CreatePaymentCommand, CreatePaymentCommandResponse>
    {
        public CreatePaymentCommandHandler(
            ILoggerFactory loggerFactory,
            IMapper mapper,
            IHttpContextAccessor httpContext) : base(loggerFactory.CreateLogger<CreatePaymentCommandHandler>(), mapper, httpContext)
        {
        }

        public async override Task<CreatePaymentCommandResponse> Handle(CreatePaymentCommand request, CancellationToken cancellationToken)
        {
            try
            {
                return new();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "Erro ao processar {Handler}.{Method}", nameof(CreateOrderCommandHandler), nameof(Handle));

                throw;
            }
        }
    }
}
