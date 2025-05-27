using AutoMapper;
using Fatec.Store.Orders.Domain.v1.Entities;

namespace Fatec.Store.Orders.Application.v1.Commands.Payments.RegisterPaymentPix
{
    public class RegisterPaymentPixProfile : Profile
    {
        public RegisterPaymentPixProfile()
        {
            CreateMap<RegisterPaymentPixCommand, Payment>(MemberList.None)
                .ForMember(dest => dest.FormOfPayment, opt => opt.MapFrom(src => src.FormOfPayment.ToString()));
        }
    }
}