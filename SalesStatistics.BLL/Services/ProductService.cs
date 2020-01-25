﻿using SalesStatistics.Core.Interfaces;
using SalesStatistics.Core.Models;
using SalesStatistics.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Linq;
using System.Data.Entity;

namespace SalesStatistics.BLL.Services
{
    public class ProductService : IService<Product>
    {
        private IRepository<Product> _repository;
        public ProductService(IRepository<Product> repository)
        {
            _repository = repository;
        }

        public async Task<Product> GetByIdAsync(int id)
        {
            return await _repository.All.Where(p => p.Id == id).FirstOrDefaultAsync<Product>();
        }

        public async Task<IEnumerable<Product>> GetTopCountAsync(int count)
        {
            var allOrderedByOrdersProducts = _repository.All.OrderBy(p => p.Orders.Count);
            if (allOrderedByOrdersProducts.Count()>count)
            {
                return await allOrderedByOrdersProducts.Take(count).ToListAsync();
            }
            return await allOrderedByOrdersProducts.ToListAsync();
            
        }
    }
}
