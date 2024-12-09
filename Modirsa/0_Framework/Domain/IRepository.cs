using System.Linq.Expressions;

namespace _0_Framework.Domain
{
    public interface IRepository <TKey,T> where T : class
    {
        Task Create(T entity);
        Task<T> Get(TKey key);
        Task<List<T>> GetAll();
        Task<bool> Exsits(Expression<Func<T,bool>> expression);
        Task SaveChanges();
    }
}
