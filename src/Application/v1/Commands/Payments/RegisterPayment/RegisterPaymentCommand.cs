using Fatec.Store.Orders.Domain.v1.Enum;
using MediatR;

namespace Fatec.Store.Orders.Application.v1.Commands.Payments.CreatePayment
{
    public class RegisterPaymentCommand : IRequest<RegisterPaymentCommandResponse>
    {
        public string DiscountCouponCode { get; set; }

        public FormOfPaymentEnum FormOfPayment { get; set; }

        public decimal TotalOriginalAmount { get; set; }

        public RegisterPaymentCardCommand PaymentCard { get; set; }
    }

    public class RegisterPaymentCardCommand
    {
        public int Cvv { get; set; }

        public string CardNumber { get; set; }

        public string CardName { get; set; }

        public string Expiration { get; set; }
    }
}
