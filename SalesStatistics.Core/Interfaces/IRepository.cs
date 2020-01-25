using System.Linq;
using System.Threading.Tasks;

namespace SalesStatistics.Core.Interfaces
{
    public interface IRepository<T> where T:class
    {
        IQueryable<T> All { get; }
        void Update(T entity);
        void Add(T entity);
        void Remove(T entity);
        Task SaveChangesAsync();
    }
}
