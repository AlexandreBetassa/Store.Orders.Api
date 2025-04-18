using AutoMapper;
using Fatec.Store.Framework.Core.Bases.v1.CommandHandler;
using Fatec.Store.Orders.Domain.v1.Entities;
using Fatec.Store.Orders.Domain.v1.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace Fatec.Store.Orders.Application.v1.Commands.Orders.CreateOrder
{
    public class CreateOrderCommandHandler : BaseCommandHandler<CreateOrderCommand, CreateOrderCommandResponse>
    {
        private readonly IOrdersRepository _ordersRepository;
        private readonly IDeliveryAddressRepository _addressRepository;
        private readonly IContactRepository _contactRepository;

        public CreateOrderCommandHandler(
            ILoggerFactory loggerFactory,
            IMapper mapper,
            IHttpContextAccessor httpContext,
            IOrdersRepository ordersRepository,
            IDeliveryAddressRepository addressRepository,
            IContactRepository contactRepository)
            : base(loggerFactory.CreateLogger<CreateOrderCommandHandler>(), mapper, httpContext)
        {
            _ordersRepository = ordersRepository;
            _addressRepository = addressRepository;
            _contactRepository = contactRepository;
        }

        public override async Task<CreateOrderCommandResponse> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var order = Mapper.Map<Order>(request);

                order.CalculateTotalDiscount();
                order.CalculateTotalAmount();

                await TryAssignAddressAsync(
                    zipCode: request.Address.ZipCode,
                    order: order);

                await TryAssignContactAsync(
                    phoneNumber: request.Contact.PhoneNumber,
                    email: request.Contact.Email,
                    order: order);

                var orderId = await _ordersRepository.CreateAsync(order);

                return new CreateOrderCommandResponse { OrderId = orderId };
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "Erro ao processar {Handler}.{Method}", nameof(CreateOrderCommandHandler), nameof(Handle));

                throw;
            }
        }

        private async Task TryAssignAddressAsync(string zipCode, Order order)
        {
            if (string.IsNullOrWhiteSpace(zipCode))
                return;

            var address = await _addressRepository.GetAddressByZipCodeAsync(zipCode: zipCode);

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