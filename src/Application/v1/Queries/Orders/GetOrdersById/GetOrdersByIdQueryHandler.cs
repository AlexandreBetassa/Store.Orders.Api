using AutoMapper;
using Fatec.Store.Framework.Core.Bases.v1.CommandHandler;
using Fatec.Store.Orders.Domain.v1.Interfaces;
using Fatec.Store.Orders.Infrastructure.CrossCutting.v1.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace Fatec.Store.Orders.Application.v1.Queries.Orders.GetOrdersById
{
    public class GetOrdersByIdQueryHandler : BaseCommandHandler<GetOrdersByIdQuery, GetOrdersByIdQueryResponse>
    {
        private readonly IOrdersRepository _ordersRepository;

        public GetOrdersByIdQueryHandler(
            ILoggerFactory loggerFactory,
            IMapper mapper,
            IHttpContextAccessor httpContext,
            IOrdersRepository ordersRepository)
                : base(loggerFactory.CreateLogger<GetOrdersByIdQueryHandler>(), mapper, httpContext)
        {
            _ordersRepository = ordersRepository;
        }

        public override async Task<GetOrdersByIdQueryResponse> Handle(GetOrdersByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var orderData = await _ordersRepository.GetByIdAsync(id: request.OrderId)
                    ?? throw new NotFoundException(message: "Pedido não localizado !!!");

                return Mapper.Map<GetOrdersByIdQueryResponse>(orderData);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "Erro metodo {handler}.{method}", nameof(GetOrdersByIdQueryHandler), nameof(Handle));

                throw;
            }
        }
    }
}