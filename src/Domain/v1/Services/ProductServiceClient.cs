using Fatec.Store.Orders.Domain.v1.Interfaces.ServiceClients;
using Fatec.Store.Orders.Domain.v1.Models.ServiceCleintes.Products.UpdateProductsStock;
using Fatec.Store.Orders.Infrastructure.CrossCutting.v1;
using Microsoft.Extensions.Options;
using System.Text;
using System.Text.Json;

namespace Fatec.Store.Orders.Domain.v1.Services
{
    public class ProductServiceClient(HttpClient httpClient, IOptions<AppsettingsConfigurations> options) : IProductServiceClient
    {
        private readonly HttpClient _httpClient = httpClient;

        private readonly string _productCepUrl = options.Value.ServiceClients.Product;

        public async Task UpdateProductsStockAsync(UpdateProductsStockRequest updateProductsStockRequest)
        {
            var request = JsonSerializer.Serialize(updateProductsStockRequest);

            var content = new StringContent(
                JsonSerializer.Serialize(updateProductsStockRequest),
                Encoding.UTF8,
                "application/json");

            await _httpClient.PutAsync($"{_productCepUrl}", content);
        }
    }
}
