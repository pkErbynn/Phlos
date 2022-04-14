using Phlosales.API.Entities;
using Phlosales.API.Models;

namespace Phlosales.API.Services
{
    public interface IProdOrderService
    {
        Task<IEnumerable<ProdOrder>> GetProdOrders();
        Task<ProdOrder> AddProdOrder(ProdOrder prodOrder);
        Task<ProdOrder> GetProdOrder(Guid prodOrderId);
        Task<ProdOrder> DeleteProdOrder(Guid prodOrderId);
    }
}
