using AutoMapper;
using Fatec.Store.Framework.Core.Bases.v1.CommandHandler;
using Fatec.Store.Orders.Application.v1.Interfaces;
using Fatec.Store.Orders.Domain.v1.Entities;
using Fatec.Store.Orders.Domain.v1.Interfaces.Repositories;
using Fatec.Store.Orders.Domain.v1.Interfaces.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace Fatec.Store.Orders.Application.v1.Commands.Orders.CreateOrder
{
    public class CreateOrderCommandHandler : BaseCommandHandler<CreateOrderCommand, CreateOrderCommandResponse>
    {
        private readonly IOrdersRepository _ordersRepository;
        private readonly IDeliveryAddressRepository _addressRepository;
        private readonly IContactRepository _contactRepository;

        private readonly IPaymentDomainService _paymentService;
        private readonly IPaymentServiceClient _paymentServiceClient;

        public CreateOrderCommandHandler(
            ILoggerFactory loggerFactory,
            IMapper mapper,
            IHttpContextAccessor httpContext,
            IOrdersRepository ordersRepository,
            IDeliveryAddressRepository addressRepository,
            IContactRepository contactRepository,
            IPaymentDomainService paymentService,
            IPaymentServiceClient paymentServiceClient)
            : base(loggerFactory.CreateLogger<CreateOrderCommandHandler>(), mapper, httpContext)
        {
            _ordersRepository = ordersRepository;
            _addressRepository = addressRepository;
            _contactRepository = contactRepository;
            _paymentService = paymentService;
            _paymentServiceClient = paymentServiceClient;
        }

        public override async Task<CreateOrderCommandResponse> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var order = Mapper.Map<Order>(request);

                order.CalculateTotalAmount();
                await CalculateDiscount(order, request.GetCouponCodeDiscount());

                await TryAssignAddressAsync(
                    zipCode: request.Address.ZipCode,
                    number: request.Address.Number,
                    order: order);

                await TryAssignContactAsync(
                    phoneNumber: request.Contact.PhoneNumber,
                    email: request.Contact.Email,
                    order: order);

                await ProcessPayment(order.Payment);

                await _paymentService.DebitCouponCodeAsync(
                    couponCode: request.GetCouponCodeDiscount(),
                    userId: request.UserId);

                var orderId = await _ordersRepository.CreateAsync(order);

                return new CreateOrderCommandResponse { OrderId = orderId };
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "Erro ao processar {Handler}.{Method}", nameof(CreateOrderCommandHandler), nameof(Handle));

                throw;
            }
        }

        private async Task ProcessPayment(Payment payment)
        {
            var registerPaymentResponse = await _paymentServiceClient.RegisterPaymentAsync(new()
            {
                PaymentType = payment.FormOfPaymentType.ToString(),
                Value = payment.TotalOriginalAmount - payment.TotalDiscount
            });

            payment.RegisterPaymentId = registerPaymentResponse.PaymentId.ToString();
        }

        private async Task CalculateDiscount(Order order, string discountCouponCode)
        {
            if (!string.IsNullOrEmpty(discountCouponCode))
                order.Payment.TotalDiscount = await _paymentService.CalculateDiscountAsync(
                                                                        originalAmount: order.GetTotalOriginalAmount(),
                                                                        couponCode: discountCouponCode);
        }

        private async Task TryAssignAddressAsync(string zipCode, string number, Order order)
        {
            if (string.IsNullOrWhiteSpace(zipCode))
                return;

            var address = await _addressRepository.GetAddressByZipCodeAndNumberAsync(zipCode: zipCode, number: number);

            if (address is not null)
            {
                order.AddressId = address.Id;
                order.Address = null;
            }
        }

        private async Task TryAssignContactAsync(string phoneNumber, string email, Order order)
        {
            if (string.IsNullOrWhiteSpace(phoneNumber) || string.IsNullOrWhiteSpace(email))
                return;

            var contact = await _contactRepository.GetContactByEmailAndPhoneNumberAsync(email: email, phoneNumber: phoneNumber);

            if (contact is not null)
            {
                order.ContactId = contact.Id;
                order.Contact = null;
            }
        }
    }
}