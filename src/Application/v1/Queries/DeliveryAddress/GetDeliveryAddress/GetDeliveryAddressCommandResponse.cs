namespace Fatec.Store.Orders.Application.v1.Queries.DeliveryAddress.GetDeliveryAddress
{
    public class GetDeliveryAddressCommandResponse
    {
        public string ZipCode { get; set; }

        public string Street { get; set; }

        public string Complement { get; set; }

        public string Neighborhood { get; set; }

        public string City { get; set; }

        public string Province { get; set; }
    }
}
