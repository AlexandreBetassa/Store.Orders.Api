using Fatec.Store.Orders.Domain.v1.Entities;
using Microsoft.EntityFrameworkCore;

namespace Fatec.Store.Orders.Infrastructure.Data.v1.Context
{
    public class OrdersDbContext(DbContextOptions<OrdersDbContext> options) : DbContext(options)
    {
        public DbSet<Order> Orders { get; set; }

        public DbSet<Payment> Payments { get; set; }

        public DbSet<DeliveryAddress> Addresses { get; set; }

        public DbSet<Product> ProductOrders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Order>()
                .HasOne(o => o.Address)
                .WithMany(a => a.Orders)
                .HasForeignKey(o => o.AddressId);

            modelBuilder.Entity<Order>()
                .HasOne(o => o.Contact)
                .WithMany(oc => oc.Orders)
                .HasForeignKey(o => o.ContactId);

            modelBuilder.Entity<Product>()
                .HasOne(po => po.Order)
                .WithMany(o => o.Products)
                .HasForeignKey(po => po.OrderId);

            modelBuilder.Entity<Product>()
                .Ignore(x => x.Status);

            modelBuilder.Entity<DeliveryAddress>()
                .Ignore(x => x.Status);

            modelBuilder.Entity<Contact>()
                .Ignore(x => x.Status);
        }
    }
}