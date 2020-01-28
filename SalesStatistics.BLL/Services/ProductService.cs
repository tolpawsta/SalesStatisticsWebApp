using SalesStatistics.Core.Interfaces;
using SalesStatistics.Core.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SalesStatistics.BLL.Services
{
    public class ProductService : IService<Product>
    {
        private IRepository<Product> _repository;
        public ProductService(IRepository<Product> repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            return await _repository.All.ToListAsync();
        }

        public async Task<Product> GetByIdAsync(int id)
        {
            return await _repository.All.Where(p => p.Id == id).FirstOrDefaultAsync<Product>();
        }

        public async Task<IEnumerable<Product>> GetTopCountAsync(int count)
        {
            var allOrderedByOrdersProducts = _repository.All.OrderBy(p => p.Orders.Count);
            if (allOrderedByOrdersProducts.Count() > count)
            {
                return await allOrderedByOrdersProducts.Take(count).ToListAsync();
            }
            return await allOrderedByOrdersProducts.ToListAsync();
        }

        public Task CreateAsync(Product entity)
        {
            _repository.Add(entity);
            return _repository.SaveChangesAsync();
        }

        public Task DeleteAsync(Product entity)
        {
            _repository.Remove(entity);
            return _repository.SaveChangesAsync();
        }

        public Task EditAsync(Product entity)
        {            
            _repository.Update(entity);
            return _repository.SaveChangesAsync();
        }
        public async Task<IEnumerable<Product>> GetEntitiesWhere(Expression<Func<Product,bool>> predicate)
        {
            return await _repository.All.Where(predicate).ToListAsync();
        }
    }
}
