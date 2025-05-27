using AutoMapper;
using Fatec.Store.Orders.Application.v1.Commands.Orders.CreateOrder.Models;
using Fatec.Store.Orders.Domain.v1.Entities;

namespace Fatec.Store.Orders.Application.v1.Commands.Orders.CreateOrder
{
    public class CreateOrderCommandProfile : Profile
    {
        public CreateOrderCommandProfile()
        {
            CreateMap<CreateOrderCommand, Order>(MemberList.None)
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => true));

            CreateMap<DeliveryAddressCommand, DeliveryAddress>(MemberList.None);

            CreateMap<ContactCommand, Contact>(MemberList.None);

            CreateMap<ProductCommand, Product>(MemberList.None);
        }
    }
}