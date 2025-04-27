using AutoMapper;
using Fatec.Store.Framework.Core.Bases.v1.CommandHandler;
using Fatec.Store.Orders.Application.v1.Queries.Orders.GetOrdersById;
using Fatec.Store.Orders.Domain.v1.Interfaces.Repositories;
using Fatec.Store.Orders.Infrastructure.CrossCutting.v1.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace Fatec.Store.Orders.Application.v1.Queries.Orders.GetOrdersByCustomerId
{
    public class GetOrdersByCustomerIdQueryHandler : BaseCommandHandler<GetOrdersByCustomerIdQuery, IEnumerable<GetOrdersByCustomerIdQueryResponse>>
    {
        private readonly IOrdersRepository _ordersRepository;

        public GetOrdersByCustomerIdQueryHandler(
            ILoggerFactory loggerFactory,
            IMapper mapper,
            IHttpContextAccessor httpContext,
            IOrdersRepository ordersRepository)
            : base(loggerFactory.CreateLogger<GetOrdersByCustomerIdQueryHandler>(), mapper, httpContext)
        {
            _ordersRepository = ordersRepository;
        }

        public override async Task<IEnumerable<GetOrdersByCustomerIdQueryResponse>> Handle(GetOrdersByCustomerIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var orderData = await _ordersRepository.GetOrdersByCustomerIdAsync(customerId: request.CustomerId)
                    ?? throw new NotFoundException(message: "Pedido não localizado !!!");

                var orderResponse = Mapper.Map<IEnumerable<GetOrdersByCustomerIdQueryResponse>>(orderData);
                orderResponse.ToList().ForEach(order => order.CalculatePaymentsAmount());

                return orderResponse;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "Erro metodo {handler}.{method}", nameof(GetOrdersByIdQueryHandler), nameof(Handle));

                throw;
            }
        }
    }
}
