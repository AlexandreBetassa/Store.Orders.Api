using AutoMapper;
using Fatec.Store.Framework.Core.Bases.v1.CommandHandler;
using Fatec.Store.Orders.Application.v1.Commands.Orders.CreateOrder;
using Fatec.Store.Orders.Application.v1.Interfaces;
using Fatec.Store.Orders.Application.v1.Models.Payment.RegisterPaymentCard;
using Fatec.Store.Orders.Domain.v1.Entities;
using Fatec.Store.Orders.Domain.v1.Interfaces.DomainServices;
using Fatec.Store.Orders.Domain.v1.Interfaces.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace Fatec.Store.Orders.Application.v1.Commands.Payments.RegisterPaymentCard
{
    public class RegisterPaymentCardCommandHandler : BaseCommandHandler<RegisterPaymentCardCommand, RegisterPaymentCardCommandResponse>
    {
        private readonly IPaymentDomainService _paymentDomainService;
        private readonly IPaymentRepository _paymentRepository;
        private readonly IPaymentServiceClient _paymentServiceClient;

        public RegisterPaymentCardCommandHandler(
            ILoggerFactory loggerFactory,
            IMapper mapper,
            IHttpContextAccessor httpContext,
            IPaymentDomainService paymentDomainService,
            IPaymentRepository paymentRepository,
            IPaymentServiceClient paymentServiceClient) : base(loggerFactory.CreateLogger<RegisterPaymentCardCommandHandler>(), mapper, httpContext)
        {
            _paymentDomainService = paymentDomainService;
            _paymentRepository = paymentRepository;
            _paymentServiceClient = paymentServiceClient;
        }

        public async override Task<RegisterPaymentCardCommandResponse> Handle(RegisterPaymentCardCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var payment = Mapper.Map<Payment>(request);

                if (!string.IsNullOrEmpty(payment.DiscountCouponCode))
                    await CalculateDiscountAsync(payment);

                var registerPaymentRequest = new RegisterPaymentCardRequest()
                {
                    FormOfPayment = request.FormOfPayment,
                    Value = payment.TotalOriginalAmount - payment.TotalDiscount
                };

                var response = await _paymentServiceClient.RegisterPaymentCardAsync(registerPaymentRequest);

                payment.RegisterPaymentId = response.PaymentId;

                await _paymentRepository.CreateAsync(payment);

                return new()
                {
                    PaymentId = payment.RegisterPaymentId
                };
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "Erro ao processar {Handler}.{Method}", nameof(CreateOrderCommandHandler), nameof(Handle));

                throw;
            }
        }

        private async Task CalculateDiscountAsync(Payment payment) =>
            payment.TotalDiscount = await _paymentDomainService.CalculateDiscountAsync(payment.TotalOriginalAmount, payment.DiscountCouponCode);
    }
}
