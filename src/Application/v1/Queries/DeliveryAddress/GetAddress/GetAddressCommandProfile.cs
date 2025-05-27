using AutoMapper;
using Fatec.Store.Orders.Application.v1.Models.ViaCep;

namespace Fatec.Store.Orders.Application.v1.Queries.DeliveryAddress.GetAddress
{
    public class GetAddressCommandProfile : Profile
    {
        public GetAddressCommandProfile()
        {
            CreateMap<ViaCepResponse, GetAddressCommandResponse>(MemberList.None)
                .ForMember(dest => dest.ZipCode, opt => opt.MapFrom(src => src.Cep))
                .ForMember(dest => dest.Province, opt => opt.MapFrom(src => src.Uf))
                .ForMember(dest => dest.Neighborhood, opt => opt.MapFrom(src => src.Bairro))
                .ForMember(dest => dest.Complement, opt => opt.MapFrom(src => src.Complemento))
                .ForMember(dest => dest.Street, opt => opt.MapFrom(src => src.Logradouro))
                .ForMember(dest => dest.City, opt => opt.MapFrom(src => src.Localidade));
        }
    }
}
