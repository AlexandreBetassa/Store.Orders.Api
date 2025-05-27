namespace Fatec.Store.Orders.Application.v1.Models.Orders
{
    public class ProductResponse
    {
        public int ProductId { get; set; }

        public decimal Price { get; set; }

        public int Quantity { get; set; }

        public string Description { get; set; }

        public string ImageUrl { get; set; }
    }
}