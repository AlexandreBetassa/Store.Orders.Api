namespace Fatec.Store.Orders.Application.v1.Commands.Orders.CreateOrder.Models
{
    public class ProductCommand
    {
        public int ProductId { get; set; }

        public string Description { get; set; }

        public string ImageUrl { get; set; }

        public decimal Price { get; set; }

        public int Quantity { get; set; }
    }
}