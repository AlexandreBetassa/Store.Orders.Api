using Fatec.Store.Orders.Application.v1.Interfaces;
using Fatec.Store.Orders.Application.v1.Models.ViaCep;
using System.Net.Http.Json;

namespace Fatec.Store.Orders.Application.v1.Services
{
    public class ViaCepService(HttpClient httpClient) : IViaCepService
    {
        private readonly HttpClient _httpClient = httpClient;


        public async Task<ViaCepResponse> GetAddressByZipCode(string zipCode)
        {
            var url = $"https://viacep.com.br/ws/{zipCode}/json/";
            var response = await _httpClient.GetAsync(url);

            if (!response.IsSuccessStatusCode)
                throw new HttpRequestException($"Erro ao consultar o CEP: {response.StatusCode}");

            var content = await response.Content.ReadFromJsonAsync<ViaCepResponse>();

            return content!;
        }
    }
}