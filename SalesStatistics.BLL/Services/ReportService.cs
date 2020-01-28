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
    public class ReportService : IService<Report>
    {
        private IRepository<Report> _repository;
        public ReportService(IRepository<Report> repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Report>> GetAllAsync()
        {
            return await _repository.All.ToListAsync();
        }

        public async Task<Report> GetByIdAsync(int id)
        {
            return await _repository.All.Where(p => p.Id == id).FirstOrDefaultAsync<Report>();
        }

        public async Task<IEnumerable<Report>> GetTopCountAsync(int count)
        {
            var allOrderedByManagersReports = _repository.All.OrderBy(p => p.Manager);
            if (allOrderedByManagersReports.Count() > count)
            {
                return await allOrderedByManagersReports.Take(count).ToListAsync();
            }
            return await allOrderedByManagersReports.ToListAsync();
        }

        public Task CreateAsync(Report entity)
        {
            _repository.Add(entity);
            return _repository.SaveChangesAsync();
        }

        public Task DeleteAsync(Report entity)
        {
            _repository.Remove(entity);
            return _repository.SaveChangesAsync();
        }

        public Task EditAsync(Report entity)
        {
            _repository.Update(entity);
            return _repository.SaveChangesAsync();
        }

        public Task<IEnumerable<Report>> GetEntitiesWhere(Expression<Func<Report, bool>> predicate)
        {
            throw new NotImplementedException();
        }
    }
}
