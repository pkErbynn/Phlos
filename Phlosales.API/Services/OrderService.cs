using Phlosales.API.DbContext;
using Phlosales.API.Models;
using System;

namespace Phlosales.API.Services
{
    public class OrderService : IOrderService
    {
        private readonly PhloDbContext _dbContext;

        public OrderService(PhloDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public async Task<IEnumerable<Order>> GetOrders()
        {
            return _dbContext.Orders.ToList();
        }

        public Task<Order> AddOrder(Order order)
        {
            throw new NotImplementedException();
        }

        public  Task<Order> GetOrder(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Order> UpdateOrder(Order order)
        {
            throw new NotImplementedException();
        }
    }
}
