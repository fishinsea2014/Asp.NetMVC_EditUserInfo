using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BLL.IBLL
{
    public interface IBaseService<T> where T: class, new()
    {
        IDBSession GetCurrentDbSession { get; } 
        IBaseDal<T> CurrentDal { get; set; }
        IQueryable<T> LoadEntities(Expression<Func<T, bool>> whereLambda);
        bool DeleteEntity(T entity);
        bool EditEntity(T entity);
        T AddEntity(T entity);
        bool SaveChanges();
        int DeteachEntities(params T[] entities);
    }
}
