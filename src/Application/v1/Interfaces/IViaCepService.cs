using Fatec.Store.Orders.Application.v1.Models.ViaCep;

namespace Fatec.Store.Orders.Application.v1.Interfaces
{
    public interface IViaCepService
    {
        Task<ViaCepResponse> GetAddressByZipCode(string zipCode);
    }
}