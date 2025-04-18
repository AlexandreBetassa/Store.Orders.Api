using AutoMapper;
using Fatec.Store.Framework.Core.Bases.v1.CommandHandler;
using Fatec.Store.Orders.Application.v1.Commands.Orders.CreateOrder;
using Fatec.Store.Orders.Application.v1.Interfaces;
using Fatec.Store.Orders.Infrastructure.CrossCutting.v1.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace Fatec.Store.Orders.Application.v1.Queries.DeliveryAddress.GetDeliveryAddress
{
    public class GetDeliveryAddressCommandHandler : BaseCommandHandler<GetDeliveryAddressCommand, GetDeliveryAddressCommandResponse>
    {
        private readonly IViaCepService _viaCepService;

        public GetDeliveryAddressCommandHandler(
            ILoggerFactory loggerFactory,
            IMapper mapper,
            IHttpContextAccessor httpContext,
            IViaCepService viaCepService)
            : base(loggerFactory.CreateLogger<GetDeliveryAddressCommandHandler>(), mapper, httpContext)
        {
            _viaCepService = viaCepService;
        }

        public override async Task<GetDeliveryAddressCommandResponse> Handle(GetDeliveryAddressCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var viaCepResponse = await _viaCepService.GetAddressByZipCode(zipCode: request.ZipCode);

                _ = bool.TryParse(viaCepResponse.Erro, out var viaCepResponseFail);

                if (viaCepResponseFail)
                    throw new NotFoundException(message: "CEP não localizado !!!");

                return Mapper.Map<GetDeliveryAddressCommandResponse>(viaCepResponse);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "Erro metodo {handler}.{method}", nameof(CreateOrderCommandHandler), nameof(Handle));

                throw;
            }
        }
    }
}