using Fatec.Store.Framework.Core.Bases.v1.Interfaces;
using Fatec.Store.Orders.Domain.v1.Entities;

namespace Fatec.Store.Orders.Domain.v1.Interfaces.Repositories
{
    public interface IDeliveryAddressRepository: IRepository<DeliveryAddress>
    {
        public Task<DeliveryAddress> GetAddressByZipCodeAndNumberAsync(string zipCode, string number);
    }
}
