using Phlosales.API.DbContexts;
using Phlosales.API.Entities;
using System;

namespace Phlosales.API.Services
{
    public class ProdOrderService : IProdOrderService
    {
        private readonly PhloSysDbContext _dbContext;

        public ProdOrderService(PhloSysDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public async Task<IEnumerable<ProdOrder>> GetProdOrders()
        {
            var prodOrders = _dbContext.ProdOrders.OrderByDescending(o => o.Price).ToList();
            if (prodOrders.Count() != 0)
            {
                return prodOrders;
            }
            throw new ArgumentException("no orders yet");
        }

        public async Task<ProdOrder> GetProdOrder(Guid prodOrderId)
        {
            if (prodOrderId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(prodOrderId));
            }

            return  _dbContext.ProdOrders.FirstOrDefault(order => order.ProdOrderId == prodOrderId);
        }

        public async Task<ProdOrder> AddProdOrder(ProdOrder prodOrder)
        {
            ThrowIfParamsNull(new List<string> { prodOrder.CustomerName, prodOrder.ProductName, prodOrder.Price.ToString() });

            prodOrder.ProdOrderId = Guid.NewGuid();

            var addedProdOrder = _dbContext.ProdOrders.Add(prodOrder);
            await _dbContext.SaveChangesAsync();

            return addedProdOrder.Entity;
        }

        public async Task<ProdOrder> DeleteProdOrderAsync(Guid prodOrderId)
        {
            if (prodOrderId == Guid.Empty)
            {
                throw new ArgumentNullException("id not provided");
            }
            var orderToDelete = _dbContext.ProdOrders.FirstOrDefault(order => order.ProdOrderId == prodOrderId);
            if (orderToDelete == null)
            {
                throw new ArgumentNullException($"order not found: {prodOrderId}");
            }
            _dbContext.Remove(orderToDelete);
            await _dbContext.SaveChangesAsync();
            return await Task.FromResult(orderToDelete);
        }

        public async Task<ProdOrder> UpdateProdOrderAsync(ProdOrder prodOrder)
        {
            if (prodOrder == null)
            {
                throw new ArgumentException("order can not be null");
            }
            ThrowIfParamsNull(new List<string> { prodOrder.CustomerName, prodOrder.ProductName, prodOrder.Price.ToString() });

            var orderToUpdate = _dbContext.ProdOrders.FirstOrDefault(order => order.ProdOrderId == prodOrder.ProdOrderId);
            if (orderToUpdate == null)
            {
                throw new ArgumentNullException($"order not found: {prodOrder.ProdOrderId}");
            }

            orderToUpdate.CustomerName = prodOrder.CustomerName;
            orderToUpdate.ProductName = prodOrder.ProductName;
            orderToUpdate.Price = prodOrder.Price;

            await _dbContext.SaveChangesAsync();

            return orderToUpdate;
            //return await Task.FromResult(orderToUpdate);
        }

        private void ThrowIfParamsNull(IEnumerable<object> params_)
        {
            foreach (var param in params_)
            {
                if(param is null)
                {
                    throw new ArgumentNullException(nameof(param));
                }
            }
        }
    }
}
