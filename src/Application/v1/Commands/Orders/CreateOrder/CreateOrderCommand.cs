using Fatec.Store.Orders.Application.v1.Commands.Orders.CreateOrder.Models;
using MediatR;

namespace Fatec.Store.Orders.Application.v1.Commands.Orders.CreateOrder
{
    public class CreateOrderCommand : IRequest<CreateOrderCommandResponse>
    {
        public int UserId { get; set; }

        public DeliveryAddressCommand Address { get; set; }

        public PaymentCommand Payment { get; set; }

        public ContactCommand Contact { get; set; }

        public IEnumerable<ProductCommand> Products { get; set; }

        public DateTime OrderDate { get; set; }

        public string GetCouponCodeDiscount() => Payment?.DiscountCouponCode ?? string.Empty;
    }
}