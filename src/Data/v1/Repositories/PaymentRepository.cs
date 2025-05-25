using Fatec.Store.Framework.Core.Bases.v1.Repository;
using Fatec.Store.Orders.Domain.v1.Entities;
using Fatec.Store.Orders.Domain.v1.Interfaces.Repositories;
using Fatec.Store.Orders.Infrastructure.Data.v1.Context;

namespace Fatec.Store.Orders.Infrastructure.Data.v1.Repositories
{
    public class PaymentRepository(OrdersDbContext context) : BaseRepository<Payment>(context), IPaymentRepository
    {
    }
}