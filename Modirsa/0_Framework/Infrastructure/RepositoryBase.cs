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

        public void Create(T entity)
        {
            _context.Add(entity);
        }

        public bool Exsits(Expression<Func<T, bool>> expression)
        {
           return _context.Set<T>().Any(expression);
        }

        public T Get(TKey key)
        {
            return _context.Find<T>(key);
        }

        public List<T> GetAll()
        {
           return _context.Set<T>().ToList();   
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
