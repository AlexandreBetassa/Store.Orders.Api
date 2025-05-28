using AutoMapper;
using Fatec.Store.Framework.Core.Bases.v1.CommandHandler;
using Fatec.Store.Orders.Application.v1.Shared.Extensions;
using Fatec.Store.Orders.Domain.v1.Entities;
using Fatec.Store.Orders.Domain.v1.Interfaces.DomainServices;
using Fatec.Store.Orders.Domain.v1.Interfaces.Repositories;
using Fatec.Store.Orders.Domain.v1.Interfaces.ServiceClients;
using Fatec.Store.Orders.Domain.v1.Models.ServiceCleintes.Products.UpdateProductsStock;
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
        private readonly IProductServiceClient _productServiceClient;

        private readonly string _userId;

        public CreateOrderCommandHandler(
            ILoggerFactory loggerFactory,
            IMapper mapper,
            IHttpContextAccessor httpContext,
            IOrdersRepository ordersRepository,
            IDeliveryAddressRepository addressRepository,
            IContactRepository contactRepository,
            IPaymentDomainService paymentService,
            IProductServiceClient productServiceClient)
            : base(loggerFactory.CreateLogger<CreateOrderCommandHandler>(), mapper, httpContext)
        {
            _ordersRepository = ordersRepository;
            _addressRepository = addressRepository;
            _contactRepository = contactRepository;
            _paymentService = paymentService;
            _productServiceClient = productServiceClient;
            _userId = httpContext.GetUserId();
        }

        public override async Task<CreateOrderCommandResponse> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var order = Mapper.Map<Order>(request);
                order.UserId = int.Parse(_userId);

                await ApplyOrderInformationsAsync(order, request);
                await ApplyOrderUpdatesAsync(order, request);

                var orderId = await _ordersRepository.CreateAsync(order);

                return new CreateOrderCommandResponse { OrderId = orderId };
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "Erro ao processar {Handler}.{Method}", nameof(CreateOrderCommandHandler), nameof(Handle));

                throw;
            }
        }

        private async Task ApplyOrderInformationsAsync(Order order, CreateOrderCommand request)
        {
            await TryAssignAddressAsync(
                zipCode: request.Address.ZipCode,
                number: request.Address.Number,
                order: order);

            await TryAssignContactAsync(
                phoneNumber: request.Contact.PhoneNumber,
                email: request.Contact.Email,
                order: order);
        }

        private async Task ApplyOrderUpdatesAsync(Order order, CreateOrderCommand request)
        {
            try
            {
                if (!string.IsNullOrEmpty(order.CouponCode))
                    await _paymentService.DebitCouponCodeAsync(couponCode: request.CouponCode, userId: order.UserId);

                await UpdateProductsStock(order.Products);
            }
            catch (Exception ex)
            {
                Logger.LogWarning(ex, "Erro {Handler}.{Method}", nameof(CreateOrderCommandHandler), nameof(ApplyOrderUpdatesAsync));
            }
        }

        private async Task UpdateProductsStock(IEnumerable<Product> products) =>
            await _productServiceClient.UpdateProductsStockAsync(
                updateProductsStockRequest: new UpdateProductsStockRequest(Mapper.Map<IEnumerable<UpdateProductsStock>>(products)));

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