using AutoMapper;
using Fatec.Store.Orders.Application.v1.Models.Orders;
using Fatec.Store.Orders.Domain.v1.Entities;

namespace Fatec.Store.Orders.Application.v1.Queries.Orders.GetOrdersById
{
    public class GetOrdersByIdQueryProfile : Profile
    {
        public GetOrdersByIdQueryProfile()
        {
            CreateMap<Order, GetOrdersByIdQueryResponse>(MemberList.None);

            CreateMap<Domain.v1.Entities.DeliveryAddress, DeliveryAddressResponse>(MemberList.None);

            CreateMap<Contact, ContactResponse>(MemberList.None);

            CreateMap<Payment, PaymentResponse>(MemberList.None);

            CreateMap<Product, ProductResponse>(MemberList.None);
        }
    }
}