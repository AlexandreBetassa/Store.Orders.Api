using Fatec.Store.Orders.Domain.v1.Enum;
using MediatR;

namespace Fatec.Store.Orders.Application.v1.Commands.Payments.RegisterPaymentPix
{
    public class RegisterPaymentPixCommand : IRequest<RegisterPaymentPixCommandResponse>
    {
        public string? PixPayload { get; set; }

        public string? DiscountCouponCode { get; set; }

        public decimal TotalOriginalAmount { get; set; }

        public FormOfPaymentEnum FormOfPayment { get; set; }
    }
}