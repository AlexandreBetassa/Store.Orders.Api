using Fatec.Store.Orders.Application.v1.Models.ViaCep;

namespace Fatec.Store.Orders.Application.v1.Interfaces
{
    public interface IViaCepServiceClient
    {
        Task<ViaCepResponse> GetAddressByZipCode(string zipCode);
    }
}