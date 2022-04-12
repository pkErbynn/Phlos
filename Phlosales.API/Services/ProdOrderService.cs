﻿using Phlosales.API.Data;
using Phlosales.API.DbContext;
using Phlosales.API.Entities;
using Phlosales.API.Models;
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
            var prodOrders = _dbContext.ProdOrders.ToList();

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

            return  _dbContext.ProdOrders.FirstOrDefault(order => order.ProdOrderId == prodOrderId); ;
        }

        public async Task<ProdOrder> AddProdOrder(ProdOrder prodOrder)
        {
            if(prodOrder == null)
            {
                throw new ArgumentException("order can not be null");
            }
            ThrowIfParamsNull(new List<string> { prodOrder.CustomerName, prodOrder.ProductName, prodOrder.Price.ToString() });

            prodOrder.ProdOrderId = Guid.NewGuid();

            var addedProdOrder = _dbContext.ProdOrders.Add(prodOrder);
            await _dbContext.SaveChangesAsync();

            return addedProdOrder.Entity;
        }

        public Task<ProdOrder> UpdateProdOrder(ProdOrder prodOrder)
        {
            throw new NotImplementedException();
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