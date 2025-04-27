using AutoMapper;
using Fatec.Store.Framework.Core.Bases.v1.CommandHandler;
using Fatec.Store.Orders.Domain.v1.Interfaces.Repositories;
using Fatec.Store.Orders.Infrastructure.CrossCutting.v1.Exceptions;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace Fatec.Store.Orders.Application.v1.Commands.Orders.PatchOrder
{
    public class PatchOrderCommandHandler : BaseCommandHandler<PatchOrderCommand, Unit>
    {
        private readonly IOrdersRepository _ordersRepository;

        public PatchOrderCommandHandler(
            ILoggerFactory loggerFactory,
            IMapper mapper,
            IHttpContextAccessor httpContext,
            IOrdersRepository ordersRepository) : base(loggerFactory.CreateLogger<PatchOrderCommandHandler>(), mapper, httpContext)
        {
            _ordersRepository = ordersRepository;
        }

        public override async Task<Unit> Handle(PatchOrderCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var order = await _ordersRepository.GetByIdAsync(request.OrderId);

                if (order is null) throw new NotFoundException(message: "Pedido não encontrado !!!");

                await _ordersRepository.PatchAsync(order.Id, order => order.SetProperty(x => x.Status, false));

                return Unit.Value;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "Erro ao processar {Handler}.{Method}", nameof(PatchOrderCommandHandler), nameof(Handle));

                throw;
            }
        }
    }
}
