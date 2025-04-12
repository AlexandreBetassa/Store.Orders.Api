using Fatec.Store.Framework.Core.Bases.v1.Entities;

namespace Fatec.Store.Orders.Domain.v1.Entities
{
    public class Contact : BaseEntity
    {
        public string PhoneNumber { get; set; }

        public string Email { get; set; }

        public IEnumerable<Order> Orders { get; set; }
    }
}
