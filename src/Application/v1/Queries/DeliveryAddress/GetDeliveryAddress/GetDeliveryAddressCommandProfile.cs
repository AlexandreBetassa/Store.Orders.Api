using AutoMapper;
using Fatec.Store.Orders.Application.v1.Models.ViaCep;

namespace Fatec.Store.Orders.Application.v1.Queries.DeliveryAddress.GetDeliveryAddress
{
    public class GetDeliveryAddressCommandProfile : Profile
    {
        public GetDeliveryAddressCommandProfile()
        {
            CreateMap<ViaCepResponse, GetDeliveryAddressCommandResponse>(MemberList.None)
                .ForMember(dest => dest.ZipCode, opt => opt.MapFrom(src => src.Cep))
                .ForMember(dest => dest.Province, opt => opt.MapFrom(src => src.Uf))
                .ForMember(dest => dest.Neighborhood, opt => opt.MapFrom(src => src.Bairro))
                .ForMember(dest => dest.Complement, opt => opt.MapFrom(src => src.Complemento))
                .ForMember(dest => dest.City, opt => opt.MapFrom(src => src.Localidade));
        }
    }
}
