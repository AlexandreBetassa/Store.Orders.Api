using AutoMapper;
using Fatec.Store.Orders.Application.v1.Commands.Orders.CreateOrder.Models;
using Fatec.Store.Orders.Domain.v1.Entities;

namespace Fatec.Store.Orders.Application.v1.Commands.Orders.CreateOrder
{
    public class CreateOrderCommandProfile : Profile
    {
        public CreateOrderCommandProfile()
        {
            CreateMap<CreateOrderCommand, Order>(MemberList.Source);

            CreateMap<DeliveryAddressCommand, DeliveryAddress>(MemberList.Source);

            CreateMap<FormOfPaymentCommand, FormOfPayment>(MemberList.Source)
                .ForMember(dest => dest.TotalAmount, src => src.MapFrom(opt => opt.Amount))
                .ForMember(dest => dest.FormOfPaymentType, src => src.MapFrom(opt => opt.FormOfPaymentType));

            CreateMap<ContactCommand, Contact>(MemberList.Source);

            CreateMap<ProductCommand, Product>(MemberList.Source);
        }
    }
}
