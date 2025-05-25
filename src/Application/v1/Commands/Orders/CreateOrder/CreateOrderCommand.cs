using Fatec.Store.Orders.Application.v1.Commands.Orders.CreateOrder.Models;
using MediatR;
using System.Text.Json.Serialization;

namespace Fatec.Store.Orders.Application.v1.Commands.Orders.CreateOrder
{
    public class CreateOrderCommand : IRequest<CreateOrderCommandResponse>
    {
        [JsonIgnore]
        public int UserId { get; set; }

        public DeliveryAddressCommand Address { get; set; }

        public string? CouponCode { get; set; }

        public int PaymentId { get; set; }

        public decimal TotalPayment { get; set; }

        public ContactCommand Contact { get; set; }

        public IEnumerable<ProductCommand> Products { get; set; }

        [JsonIgnore]
        public DateTime OrderDate { get; set; } = DateTime.Now;
    }
}