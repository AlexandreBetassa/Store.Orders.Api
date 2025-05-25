using AutoMapper;
using Fatec.Store.Framework.Core.Bases.v1.CommandHandler;
using Fatec.Store.Orders.Application.v1.Commands.Orders.CreateOrder;
using Fatec.Store.Orders.Application.v1.Interfaces;
using Fatec.Store.Orders.Application.v1.Models.Payment.RegisterPayment;
using Fatec.Store.Orders.Domain.v1.Entities;
using Fatec.Store.Orders.Domain.v1.Enum;
using Fatec.Store.Orders.Domain.v1.Interfaces.DomainServices;
using Fatec.Store.Orders.Domain.v1.Interfaces.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace Fatec.Store.Orders.Application.v1.Commands.Payments.CreatePayment
{
    public class RegisterPaymentCommandHandler : BaseCommandHandler<RegisterPaymentCommand, RegisterPaymentCommandResponse>
    {
        private readonly IPaymentDomainService _paymentDomainService;
        private readonly IPaymentRepository _paymentRepository;
        private readonly IPaymentServiceClient _paymentServiceClient;

        public RegisterPaymentCommandHandler(
            ILoggerFactory loggerFactory,
            IMapper mapper,
            IHttpContextAccessor httpContext,
            IPaymentDomainService paymentDomainService,
            IPaymentRepository paymentRepository,
            IPaymentServiceClient paymentServiceClient) : base(loggerFactory.CreateLogger<RegisterPaymentCommandHandler>(), mapper, httpContext)
        {
            _paymentDomainService = paymentDomainService;
            _paymentRepository = paymentRepository;
            _paymentServiceClient = paymentServiceClient;
        }

        public async override Task<RegisterPaymentCommandResponse> Handle(RegisterPaymentCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var payment = Mapper.Map<Payment>(request);

                if (!string.IsNullOrEmpty(payment.DiscountCouponCode))
                    await CalculateDiscountAsync(payment);

                var registerPaymentRequest = new RegisterPaymentRequest()
                {
                    PaymentType = payment.FormOfPayment,
                    Value = payment.TotalOriginalAmount - payment.TotalDiscount
                };

                if (!request.FormOfPayment.Equals(FormOfPaymentEnum.Pix))
                    registerPaymentRequest.CardInformations = Mapper.Map<RegisterPaymentCardRequest>(request.PaymentCard);

                var response = await _paymentServiceClient.RegisterPaymentAsync(registerPaymentRequest);

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
