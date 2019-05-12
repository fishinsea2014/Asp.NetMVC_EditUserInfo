using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class BaseDal<T> : IBaseDal<T> where T : class, new()
    {
        private DbContext _Db = DbContextFactory.CreateContext();
        public T Add(T entity)
        {
            // throw new NotImplementedException();
            _Db.Set<T>().Add(entity);
            return entity;
        }

        public bool Delete(T entity)
        {
            _Db.Entry<T>(entity).State = System.Data.EntityState.Deleted;
            return true;

        }

        public int DeteachEntities(params T[] entities)
        {
            foreach (var entity in entities)
            {
                _Db.Entry(entity).State = System.Data.EntityState.Detached;
            }

            return entities.Count();
        }

        public IQueryable<T> LoadEntities(Expression<Func<T, bool>> whereLambda)
        {
            //throw new NotImplementedException();
            return _Db.Set<T>().Where<T>(whereLambda);
        }

        public bool Update(T entity)
        {
            _Db.Entry<T>(entity).State = System.Data.EntityState.Modified;
            return true;
        }
    }
}
