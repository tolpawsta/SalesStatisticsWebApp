using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SalesStatistics.Core.Interfaces
{
    public interface IService<T> where T : class
    {
        Task<IEnumerable<T>> GetTopCountAsync(int count);
        Task<T> GetByIdAsync(int id);
        Task<IEnumerable<T>> GetEntitiesWhere(Expression<Func<T, bool>> predicate);
        Task<IEnumerable<T>> GetAllAsync();
        Task CreateAsync(T entity);
        Task DeleteAsync(T entity);
        Task EditAsync(T entity);
    }
}
