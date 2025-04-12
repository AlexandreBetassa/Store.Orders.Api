using Fatec.Store.Orders.Domain.v1.Entities;
using Microsoft.EntityFrameworkCore;

namespace Fatec.Store.Orders.Infrastructure.Data.v1.Context
{
    public class OrdersDbContext(DbContextOptions<OrdersDbContext> options) : DbContext(options)
    {
        public DbSet<Order> Orders { get; set; }

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
                .OwnsOne(x => x.FormOfPayment);

            modelBuilder.Entity<Product>()
                .HasOne(po => po.Order)
                .WithMany(o => o.Products)
                .HasForeignKey(po => po.OrderId);

            modelBuilder.Entity<Order>()
                .HasOne(o => o.Contact)
                .WithMany(oc => oc.Orders)
                .HasForeignKey(o => o.ContactId);
        }
    }
}