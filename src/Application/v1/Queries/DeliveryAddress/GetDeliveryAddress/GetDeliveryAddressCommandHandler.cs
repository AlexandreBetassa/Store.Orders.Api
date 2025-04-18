using AutoMapper;
using Fatec.Store.Framework.Core.Bases.v1.CommandHandler;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace Fatec.Store.Orders.Application.v1.Queries.DeliveryAddress.GetDeliveryAddress
{
    public class GetDeliveryAddressCommandHandler : BaseCommandHandler<GetDeliveryAddressCommand, GetDeliveryAddressCommandResponse>
    {
        public GetDeliveryAddressCommandHandler(ILoggerFactory loggerFactory, IMapper mapper, IHttpContextAccessor httpContext)
            : base(loggerFactory.CreateLogger<GetDeliveryAddressCommandHandler>(), mapper, httpContext)
        {
        }

        public override async Task<GetDeliveryAddressCommandResponse> Handle(GetDeliveryAddressCommand request, CancellationToken cancellationToken)
        {
            try
            {


                return new();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
