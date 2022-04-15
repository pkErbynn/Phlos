using Microsoft.EntityFrameworkCore;
using Phlosales.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace Phlosales.API.Data
{
    public class PhloSysDbContext : DbContext, IPhloSysDbContext
    {
        public PhloSysDbContext(DbContextOptions<PhloSysDbContext> options)
                : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProdOrder>().HasKey(e => e.ProdOrderId);
            modelBuilder.Entity<ProdOrder>().HasData(
                    new ProdOrder()
                    {
                        ProdOrderId = Guid.NewGuid(),
                        CustomerName = "Chris",
                        Price = 20,
                        ProductName = "laptop"
                    },
                     new ProdOrder()
                     {
                         ProdOrderId = Guid.NewGuid(),
                         CustomerName = "John",
                         Price = 20,
                         ProductName = "phone"
                     },
                       new ProdOrder()
                       {
                           ProdOrderId = Guid.NewGuid(),
                           CustomerName = "Raph",
                           Price = 25,
                           ProductName = "airpod"
                       }

             ); ;

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<ProdOrder> ProdOrders { get; set; }

    }
}


