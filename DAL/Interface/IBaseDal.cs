using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T">T must be a class and have a construction method without params.</typeparam>
    public interface IBaseDal<T> where T:class, new()
    {
        T Add(T entity);
        bool Update(T entity);

        bool Delete(T entity);

        IQueryable<T> LoadEntities(System.Linq.Expressions.Expression<Func<T, bool>> expression);

        int DeteachEntities(params T[] entities);

    }
}
