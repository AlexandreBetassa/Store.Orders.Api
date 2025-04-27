using System.Text.Json.Serialization;

namespace Fatec.Store.Orders.Domain.v1.Models.ServiceCleintes.Products.UpdateProductsStock
{
    public class UpdateProductsStockRequest(IEnumerable<UpdateProductsStock> products)
    {
        [JsonPropertyName("products")]
        public IEnumerable<UpdateProductsStock> Products { get; set; } = products;
    }

    public class UpdateProductsStock
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("quantity")]
        public int Quantity { get; set; }
    }
}