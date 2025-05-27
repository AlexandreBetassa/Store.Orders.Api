using AutoMapper;
using Fatec.Store.Framework.Core.Bases.v1.CommandHandler;
using Fatec.Store.Orders.Application.v1.Commands.Orders.CreateOrder;
using Fatec.Store.Orders.Application.v1.Interfaces;
using Fatec.Store.Orders.Infrastructure.CrossCutting.v1.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace Fatec.Store.Orders.Application.v1.Queries.DeliveryAddress.GetAddress
{
    public class GetAddressCommandHandler : BaseCommandHandler<GetAddressCommand, GetAddressCommandResponse>
    {
        private readonly IViaCepServiceClient _viaCepService;

        public GetAddressCommandHandler(
            ILoggerFactory loggerFactory,
            IMapper mapper,
            IHttpContextAccessor httpContext,
            IViaCepServiceClient viaCepService)
            : base(loggerFactory.CreateLogger<GetAddressCommandHandler>(), mapper, httpContext)
        {
            _viaCepService = viaCepService;
        }

        public override async Task<GetAddressCommandResponse> Handle(GetAddressCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var viaCepResponse = await _viaCepService.GetAddressByZipCode(zipCode: request.ZipCode);

                _ = bool.TryParse(viaCepResponse.Erro, out var viaCepResponseFail);

                if (viaCepResponseFail)
                    throw new NotFoundException(message: "CEP não localizado !!!");

                return Mapper.Map<GetAddressCommandResponse>(viaCepResponse);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "Erro metodo {handler}.{method}", nameof(CreateOrderCommandHandler), nameof(Handle));

                throw;
            }
        }
    }
}