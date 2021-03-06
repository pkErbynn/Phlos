using Phlosales.API.Entities;

namespace Phlosales.API.Services
{
    public interface IProdOrderService
    {
        Task<IEnumerable<ProdOrder>> GetProdOrders();
        Task<ProdOrder> AddProdOrder(ProdOrder prodOrder);
        Task<ProdOrder> GetProdOrder(Guid prodOrderId);
        Task<ProdOrder> DeleteProdOrderAsync(Guid prodOrderId);
        Task<ProdOrder> UpdateProdOrderAsync(ProdOrder prodOrder);
    }
}
