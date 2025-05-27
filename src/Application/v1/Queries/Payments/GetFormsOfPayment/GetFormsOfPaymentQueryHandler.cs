using AutoMapper;
using Fatec.Store.Framework.Core.Bases.v1.CommandHandler;
using Fatec.Store.Orders.Infrastructure.CrossCutting.v1;
using Fatec.Store.Orders.Infrastructure.CrossCutting.v1.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Fatec.Store.Orders.Application.v1.Queries.Payments.GetFormsOfPayment
{
    public class GetFormsOfPaymentQueryHandler : BaseCommandHandler<GetFormsOfPaymentQuery, GetFormsOfPaymentQueryResponse>
    {
        private readonly PaymentsConfiguration _paymentsConfiguration;
        public GetFormsOfPaymentQueryHandler(
            ILoggerFactory loggerFactory,
            IMapper mapper,
            IHttpContextAccessor httpContext,
            IOptions<AppsettingsConfigurations> configurations) : base(loggerFactory.CreateLogger<GetFormsOfPaymentQueryHandler>(), mapper, httpContext)
        {
            _paymentsConfiguration = configurations.Value.PaymentsConfiguration;
        }

        public async override Task<GetFormsOfPaymentQueryResponse> Handle(GetFormsOfPaymentQuery request, CancellationToken cancellationToken)
        {
            return new GetFormsOfPaymentQueryResponse()
            {
                FormsOfPaymentsAllowed = _paymentsConfiguration.FormsOfPaymentsAllowed,
                PaymentsMethodsCardAllowed = _paymentsConfiguration.PaymentsMethodsCardAllowed,
                InstallmentOptions = _paymentsConfiguration.InstallmentOptions
            };
        }
    }
}
