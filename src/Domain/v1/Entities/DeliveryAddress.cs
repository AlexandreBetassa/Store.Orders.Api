using Fatec.Store.Framework.Core.Bases.v1.Entities;

namespace Fatec.Store.Orders.Domain.v1.Entities
{
    public class DeliveryAddress : BaseEntity
    {
        public string Street { get; set; }

        public string Neighborhood { get; set; }

        public string Number { get; set; }

        public string City { get; set; }

        public string Province { get; set; }

        public string Country { get; set; }

        public string Complement { get; set; }

        public string ZipCode { get; set; }

        public IEnumerable<Order> Orders { get; set; }
    }
}