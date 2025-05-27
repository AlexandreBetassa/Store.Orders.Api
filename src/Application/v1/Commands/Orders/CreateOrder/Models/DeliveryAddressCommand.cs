namespace Fatec.Store.Orders.Application.v1.Commands.Orders.CreateOrder.Models
{
    public class DeliveryAddressCommand
    {
        public string Street { get; set; }

        public string Neighborhood { get; set; }

        public string Number { get; set; }

        public string City { get; set; }

        public string Province { get; set; }

        public string Complement { get; set; }

        public string ZipCode { get; set; }
    }
}
