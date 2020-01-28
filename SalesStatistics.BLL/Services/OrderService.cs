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
    public class OrderService : IService<Order>
    {
        private IRepository<Order> _repository;
        public OrderService(IRepository<Order> repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Order>> GetAllAsync()
        {
            return await _repository.All.ToListAsync();
        }

        public async Task<Order> GetByIdAsync(int id)
        {
            return await _repository.All.Where(p => p.Id == id).FirstOrDefaultAsync<Order>();
        }

        public async Task<IEnumerable<Order>> GetTopCountAsync(int count)
        {
            var allOrders = _repository.All.OrderBy(p => p.Price);
            if (allOrders.Count() > count)
            {
                return await allOrders.Take(count).ToListAsync();
            }
            return await allOrders.ToListAsync();
        }

        public Task CreateAsync(Order entity)
        {
            _repository.Add(entity);
            return _repository.SaveChangesAsync();
        }

        public Task DeleteAsync(Order entity)
        {
            _repository.Remove(entity);
            return _repository.SaveChangesAsync();
        }

        public Task EditAsync(Order entity)
        {
            _repository.Update(entity);
            return _repository.SaveChangesAsync();
        }
        public async Task<IEnumerable<Order>> GetEntitiesWhere(Expression<Func<Order, bool>> predicate)
        {
            return await _repository.All.Where(predicate).ToListAsync();
        }
    }
}
