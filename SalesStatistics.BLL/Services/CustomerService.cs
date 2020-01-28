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
    public class CustomerService : IService<Customer>
    {
        private IRepository<Customer> _repository;
        public CustomerService(IRepository<Customer> repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Customer>> GetAllAsync()
        {
            return await _repository.All.ToListAsync();
        }

        public async Task<Customer> GetByIdAsync(int id)
        {
            return await _repository.All.Where(p => p.Id == id).FirstOrDefaultAsync<Customer>();
        }

        public async Task<IEnumerable<Customer>> GetTopCountAsync(int count)
        {
            var allOrderedByOrdersProducts = _repository.All.OrderBy(p => p.Orders.Count);
            if (allOrderedByOrdersProducts.Count() > count)
            {
                return await allOrderedByOrdersProducts.Take(count).ToListAsync();
            }
            return await allOrderedByOrdersProducts.ToListAsync();
        }

        public Task CreateAsync(Customer entity)
        {
            _repository.Add(entity);
            return _repository.SaveChangesAsync();
        }

        public Task DeleteAsync(Customer entity)
        {
            _repository.Remove(entity);
            return _repository.SaveChangesAsync();
        }

        public Task EditAsync(Customer entity)
        {
            _repository.Update(entity);
            return _repository.SaveChangesAsync();
        }
        public async Task<IEnumerable<Customer>> GetEntitiesWhere(Expression<Func<Customer, bool>> predicate)
        {
            return await _repository.All.Where(predicate).ToListAsync();
        }
    }
}
