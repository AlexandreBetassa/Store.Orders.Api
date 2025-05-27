using Fatec.Store.Orders.Domain.v1.Enum;
using MediatR;

namespace Fatec.Store.Orders.Application.v1.Commands.Payments.RegisterPaymentCard
{
    public class RegisterPaymentCardCommand : IRequest<RegisterPaymentCardCommandResponse>
    {
        public string? DiscountCouponCode { get; set; }

        public decimal TotalOriginalAmount { get; set; }

        public int Cvv { get; set; }

        public string CardNumber { get; set; }

        public string CardName { get; set; }

        public string Expiration { get; set; }

        public int Installments { get; set; }

        public FormOfPaymentEnum FormOfPayment { get; set; }

    }
}
