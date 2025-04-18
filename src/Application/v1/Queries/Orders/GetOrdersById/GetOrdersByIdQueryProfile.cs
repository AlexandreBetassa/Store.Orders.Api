using AutoMapper;
using Fatec.Store.Orders.Application.v1.Models.Orders;
using Fatec.Store.Orders.Domain.v1.Entities;

namespace Fatec.Store.Orders.Application.v1.Queries.Orders.GetOrdersById
{
    public class GetOrdersByIdQueryProfile : Profile
    {
        public GetOrdersByIdQueryProfile()
        {
            CreateMap<Order, GetOrdersByIdQueryResponse>();

            CreateMap<Domain.v1.Entities.DeliveryAddress, DeliveryAddressResponse>();

            CreateMap<Contact, ContactResponse>();

            CreateMap<FormOfPayment, FormOfPaymentResponse>(MemberList.None);

            CreateMap<Product, ProductResponse>();
        }
    }
}