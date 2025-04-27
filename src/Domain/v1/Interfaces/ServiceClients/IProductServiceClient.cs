using Fatec.Store.Orders.Domain.v1.Models.ServiceCleintes.Products.UpdateProductsStock;

namespace Fatec.Store.Orders.Domain.v1.Interfaces.ServiceClients
{
    public interface IProductServiceClient
    {
        Task UpdateProductsStockAsync(UpdateProductsStockRequest updateProductsStockRequest);
    }
}