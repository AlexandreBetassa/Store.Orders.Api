using Fatec.Store.Framework.Core.Bases.v1.Repository;
using Fatec.Store.Orders.Domain.v1.Entities;
using Fatec.Store.Orders.Domain.v1.Interfaces;
using Fatec.Store.Orders.Infrastructure.Data.v1.Context;
using Microsoft.EntityFrameworkCore;

namespace Fatec.Store.Orders.Infrastructure.Data.v1.Repositories
{
    public class DeliveryAddressRepository(OrdersDbContext context) : BaseRepository<DeliveryAddress>(context), IDeliveryAddressRepository
    {
        public async Task<DeliveryAddress?> GetAddressByZipCodeAsync(string zipCode) =>
             await Context.Set<DeliveryAddress>().AsNoTracking().FirstOrDefaultAsync(x => x.ZipCode.Equals(zipCode));
    }
}