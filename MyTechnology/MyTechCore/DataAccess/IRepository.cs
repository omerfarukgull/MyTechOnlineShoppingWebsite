using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MyTechData.Abstract
{
    public interface IRepository<T> where T : class, new()
    {
        T Get(Expression<Func<T,bool>>filter = null);
        List<T> GetList(Expression<Func<T, bool>> filter = null);
        void Create(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
