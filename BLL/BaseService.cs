using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL
{
    public abstract class BaseService<T> : IBLL.IBaseService<T> where T : class, new()
    {
        public IDBSession GetCurrentDbSession
        {
            get
            {
                return DALFactory.DBSessionFactory.CreateDbSession();
            }
        }

        public IBaseDal<T> CurrentDal { get ; set; }

        public abstract void SetCurrentDal();

        public BaseService()
        {
            
            SetCurrentDal();
        }

        public T AddEntity(T entity)
        {
            CurrentDal.Add(entity);
            var r = this.SaveChanges();

            return entity;
        }

        public bool DeleteEntity(T entity)
        {
            CurrentDal.Delete(entity);
            return this.SaveChanges();
        }

        public int DeteachEntities(params T[] entities)
        {
            return CurrentDal.DeteachEntities(entities);
        }

        public bool EditEntity(T entity)
        {
            CurrentDal.Update(entity);
            return this.SaveChanges();
        }

        public IQueryable<T> LoadEntities(Expression<Func<T, bool>> whereLambda)
        {
            return CurrentDal.LoadEntities(whereLambda);
        }

        public bool SaveChanges()
        {
            return GetCurrentDbSession.SaveChange();
        }
    }

}