using Microsoft.EntityFrameworkCore;
using Phlosales.API.Entities;
using Microsoft.EntityFrameworkCore;

// Data access layer on EF....bridge btn Domain classes and database

namespace Phlosales.API.DbContexts
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
            modelBuilder.Entity<ProdOrder>().HasData(   // seeding data to db after registering this context
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


