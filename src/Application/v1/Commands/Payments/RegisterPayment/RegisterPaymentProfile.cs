using AutoMapper;
using Fatec.Store.Orders.Application.v1.Commands.Payments.CreatePayment;
using Fatec.Store.Orders.Application.v1.Models.Payment.RegisterPayment;
using Fatec.Store.Orders.Domain.v1.Entities;

namespace Fatec.Store.Orders.Application.v1.Commands.Payments.RegisterPayment
{
    public class RegisterPaymentProfile : Profile
    {
        public RegisterPaymentProfile()
        {
            CreateMap<RegisterPaymentCommand, Payment>(MemberList.None)
                .ForMember(dest => dest.DiscountCouponCode, opt => opt.MapFrom(src => src.DiscountCouponCode))
                .ForMember(dest => dest.FormOfPayment, opt => opt.MapFrom(src => src.FormOfPayment.ToString()));

            CreateMap<RegisterPaymentCardCommand, RegisterPaymentCardRequest>(MemberList.None);
        }
    }
}
