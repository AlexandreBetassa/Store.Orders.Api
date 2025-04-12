using AutoMapper;
using Fatec.Store.Framework.Core.Bases.v1.CommandHandler;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace Fatec.Store.Orders.Application.v1.Commands.CreateOrder
{
    public class CreateOrderCommandHandler : BaseCommandHandler<CreateOrderCommand, Unit>
    {
        public CreateOrderCommandHandler(
            ILoggerFactory loggerFactory,
            IMapper mapper,
            IHttpContextAccessor httpContext)
            : base(loggerFactory.CreateLogger<CreateOrderCommandHandler>(), mapper, httpContext)
        {
        }

        public override Task<Unit> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
