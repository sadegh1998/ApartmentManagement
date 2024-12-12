using System.Linq.Expressions;

namespace _0_Framework.Domain
{
    public interface IRepository <TKey,T> where T : class
    {
        Task CreateAsync(T entity);
        Task<T> GetAsync(TKey key);
        Task<List<T>> GetAllAsync();
        Task<bool> ExsitsAsync(Expression<Func<T,bool>> expression);
        Task SaveChangesAsync();
    }
}
