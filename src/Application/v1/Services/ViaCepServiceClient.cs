using Fatec.Store.Orders.Application.v1.Interfaces;
using Fatec.Store.Orders.Application.v1.Models.ViaCep;
using Fatec.Store.Orders.Infrastructure.CrossCutting.v1;
using Microsoft.Extensions.Options;
using System.Net.Http.Json;

namespace Fatec.Store.Orders.Application.v1.Services
{
    public class ViaCepServiceClient(HttpClient httpClient, IOptions<AppsettingsConfigurations> options) : IViaCepServiceClient
    {
        private readonly HttpClient _httpClient = httpClient;

        private readonly string _viaCepUrl = options.Value.ServiceClients.ViaCep;

        public async Task<ViaCepResponse> GetAddressByZipCode(string zipCode)
        {
            var response = await _httpClient.GetAsync(string.Format(_viaCepUrl, zipCode));
            var content = await response.Content.ReadFromJsonAsync<ViaCepResponse>();

            return content!;
        }
    }
}