using _0_Framework.Domain;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace _0_Framework.Infrastructure
{
    public class RepositoryBase<TKey, T> : IRepository<TKey, T> where T : class
    {
        private readonly DbContext _context;

        public RepositoryBase(DbContext context)
        {
            _context = context;
        }

        public async Task Create(T entity)
        {
            await _context.AddAsync(entity);
        }

        public async Task<bool> Exsits(Expression<Func<T, bool>> expression)
        {
            return await _context.Set<T>().AnyAsync(expression);
        }

        public async Task<T> Get(TKey key)
        {
            return await _context.Set<T>().FindAsync(key);
        }

        public async Task<List<T>> GetAll()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task SaveChanges()
        {
           await _context.SaveChangesAsync();
        }

  
    }
}
