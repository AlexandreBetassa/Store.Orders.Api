using AutoMapper;
using Fatec.Store.Orders.Application.v1.Models.Payment.RegisterPaymentCard;
using Fatec.Store.Orders.Domain.v1.Entities;

namespace Fatec.Store.Orders.Application.v1.Commands.Payments.RegisterPaymentCard
{
    public class RegisterPaymentCardProfile : Profile
    {
        public RegisterPaymentCardProfile()
        {
            CreateMap<RegisterPaymentCardCommand, Payment>(MemberList.None);
                //.ForMember(dest => dest.FormOfPayment, opt => opt.MapFrom(src => src.FormOfPayment.ToString()));

            CreateMap<RegisterPaymentCardCommand, RegisterPaymentCardRequest>(MemberList.None);
        }
    }
}