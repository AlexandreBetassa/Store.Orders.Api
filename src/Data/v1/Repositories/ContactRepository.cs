using Fatec.Store.Framework.Core.Bases.v1.Repository;
using Fatec.Store.Orders.Domain.v1.Entities;
using Fatec.Store.Orders.Domain.v1.Interfaces.Repositories;
using Fatec.Store.Orders.Infrastructure.Data.v1.Context;
using Microsoft.EntityFrameworkCore;

namespace Fatec.Store.Orders.Infrastructure.Data.v1.Repositories
{
    public class ContactRepository(OrdersDbContext context) : BaseRepository<Contact>(context), IContactRepository
    {
        public async Task<Contact?> GetContactByEmailAndPhoneNumberAsync(string email, string phoneNumber)
        {
            return await Context.Set<Contact>()
                .FirstOrDefaultAsync(contact =>
                    contact.Email.Equals(email) &&
                    contact.PhoneNumber.Equals(phoneNumber));
        }
    }
}