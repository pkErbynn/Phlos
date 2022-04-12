using Phlosales.API.Models;

namespace Phlosales.API.Services
{
    public interface IOrderService
    {
        Task<IEnumerable<Order>> GetOrders();
        Task<Order> AddOrder(Order order);
        Task<Order> GetOrder(int id);
        Task<Order> UpdateOrder(Order order);
    }
}
