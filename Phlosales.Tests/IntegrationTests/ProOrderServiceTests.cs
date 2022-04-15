using Microsoft.EntityFrameworkCore;
using Moq;
using Phlosales.API.Data;
using Phlosales.API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Phlosales.Tests.IntegrationTests
{
    public class ProOrderServiceTests: IDisposable
    {
        private readonly DbContextOptions<PhloSysDbContext> options;

        public ProOrderServiceTests()
        {
            options = new DbContextOptionsBuilder<PhloSysDbContext>()
            .UseInMemoryDatabase(databaseName: "ProdOrderListDatabase")
            .Options;

            var mockPhloSysDbContext = new PhloSysDbContext(options);
            mockPhloSysDbContext.ProdOrders.AddRange(
                 new ProdOrder() { ProdOrderId = Guid.NewGuid(), CustomerName = "Anthony", Price = 20, ProductName = "laptop1" },
                 new ProdOrder() { ProdOrderId = Guid.NewGuid(), CustomerName = "Jerry", Price = 21, ProductName = "laptop2" },
                 new ProdOrder() { ProdOrderId = Guid.NewGuid(), CustomerName = "Grace", Price = 22, ProductName = "laptop3" }
            );
            mockPhloSysDbContext.SaveChanges();
        }

        [Fact]
        public void GetProdOrders_Success()
        {
            var phloRepository = new PhloSysDbContext(options);
            var orders = phloRepository.ProdOrders.ToList();
            Assert.Equal(3, orders.Count());
        }

        [Fact]
        public void AddProdOrder_Success()
        {
            var newCustomer = "Magie";
            var phloRepository = new PhloSysDbContext(options);
            var result = phloRepository.ProdOrders.Add(
                new ProdOrder() { ProdOrderId = Guid.NewGuid(), CustomerName = newCustomer, Price = 5000, ProductName = "mac" }
            );
            phloRepository.SaveChanges();

            Assert.Equal(newCustomer, result.Entity.CustomerName);
        }

        // clean in-mem database after each test run
        public void Dispose()
        {
            var phloRepository = new PhloSysDbContext(options);
            var orders = phloRepository.ProdOrders.ToList();
            orders.ForEach(order =>
            {
                phloRepository.ProdOrders.Remove(order);
                phloRepository.SaveChanges();
            });
        }
    }
}
