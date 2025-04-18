namespace Fatec.Store.Orders.Application.v1.Commands.Orders.CreateOrder.Models
{
    public class ProductCommand
    {
        public int ProductId { get; set; }

        public decimal Amount { get; set; }

        public int Quantity { get; set; }
    }
}