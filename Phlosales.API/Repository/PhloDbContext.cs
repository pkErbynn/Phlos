using Phlosales.API.Models;
using Microsoft.EntityFrameworkCore;

namespace Phlosales.API.DbContext
{
    public class PhloDbContext : Microsoft.EntityFrameworkCore.DbContext
    {

        public PhloDbContext(DbContextOptions<PhloDbContext> options)
                : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>().HasKey(e => e.OrderId);
            modelBuilder.Entity<Order>().HasData(
                    new Order()
                    {
                        OrderId = 1,
                        CustomerName = "Chris",
                        Price = 20,
                        ProductName = "laptop"
                    },
                     new Order()
                     {
                         OrderId = 2,
                         CustomerName = "John",
                         Price = 20,
                         ProductName = "phone"
                     }
                    
             ); ;

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Order> Orders { get; set; }

    }
}

