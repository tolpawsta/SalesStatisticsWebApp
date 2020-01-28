using SalesStatistics.Core.Interfaces;
using System;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace SalesStatistics.DAL.Entities
{
    public class EfRepository<T> : IDisposable, IRepository<T> where T : class
    {
        private readonly AppDbContext _context;
        private DbSet<T> _dbSet;
        private bool _disposed = false;
        public EfRepository(AppDbContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }
        public IQueryable<T> All => _dbSet;
        public void Add(T entity)
        {
            _dbSet.Add(entity);
        }
        public void Remove(T entity)
        {
            _dbSet.Remove(entity);
        }
        public void Update(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
        }
        public void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            _disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
        }
        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
