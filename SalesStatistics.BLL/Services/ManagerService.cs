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
    public class ManagerService : IService<Manager>
    {
        private IRepository<Manager> _repository;
        public ManagerService(IRepository<Manager> repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Manager>> GetAllAsync()
        {
            return await _repository.All.ToListAsync();
        }

        public async Task<Manager> GetByIdAsync(int id)
        {
            return await _repository.All.Where(p => p.Id == id).FirstOrDefaultAsync<Manager>();
        }

        public async Task<IEnumerable<Manager>> GetTopCountAsync(int count)
        {
            var allOrderedByOrdersReports = _repository.All.OrderBy(p => p.Reports.Count);
            if (allOrderedByOrdersReports.Count() > count)
            {
                return await allOrderedByOrdersReports.Take(count).ToListAsync();
            }
            return await allOrderedByOrdersReports.ToListAsync();
        }

        public Task CreateAsync(Manager entity)
        {
            _repository.Add(entity);
            return _repository.SaveChangesAsync();
        }

        public Task DeleteAsync(Manager entity)
        {
            _repository.Remove(entity);
            return _repository.SaveChangesAsync();
        }

        public Task EditAsync(Manager entity)
        {
            _repository.Update(entity);
            return _repository.SaveChangesAsync();
        }
        public async Task<IEnumerable<Manager>> GetEntitiesWhere(Expression<Func<Manager, bool>> predicate)
        {
            return await _repository.All.Where(predicate).ToListAsync();
        }
    }
}
