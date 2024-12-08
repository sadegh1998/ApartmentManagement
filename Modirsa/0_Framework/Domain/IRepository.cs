using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace _0_Framework.Domain
{
    public interface IRepository <TKey,T> where T : class
    {
        void Create(T entity);
        T Get(TKey key);
        List<T> GetAll();
        bool Exsits(Expression<Func<T,bool>> expression);
        void SaveChanges();
    }
}
