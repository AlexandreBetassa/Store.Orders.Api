using AutoMapper;
using Fatec.Store.Framework.Core.Bases.v1.CommandHandler;
using Fatec.Store.Orders.Domain.v1.Entities;
using Fatec.Store.Orders.Domain.v1.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace Fatec.Store.Orders.Application.v1.Commands.Orders.CreateOrder
{
    public class CreateOrderCommandHandler : BaseCommandHandler<CreateOrderCommand, Unit>
    {
        private readonly IOrdersRepository _ordersRepository;

        public CreateOrderCommandHandler(
            ILoggerFactory loggerFactory,
            IMapper mapper,
            IHttpContextAccessor httpContext,
            IOrdersRepository ordersRepository)
            : base(loggerFactory.CreateLogger<CreateOrderCommandHandler>(), mapper, httpContext)
        {
            _ordersRepository = ordersRepository;
        }

        public override async Task<Unit> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var order = Mapper.Map<Order>(request);

                order.CalculateTotalDiscount();
                order.CalculateTotalAmount();

                await _ordersRepository.CreateAsync(order);
                await _ordersRepository.SaveChangesAsync();

                return Unit.Value;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "Erro metodo {handler}.{method}", nameof(CreateOrderCommandHandler), nameof(Handle));

                throw;
            }
        }
    }
}