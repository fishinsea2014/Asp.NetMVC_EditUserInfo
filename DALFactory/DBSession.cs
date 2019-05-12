using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interface;

namespace DALFactory
{
    public class DBSession : DAL.IDBSession
    {
        public DbContext Db
        {
            get { return DAL.DbContextFactory.CreateContext(); }
        }

        private IUserDal _UserDal;
        public IUserDal UserDal
        {
            get
            {
                if (_UserDal == null)
                {
                    _UserDal = AbstractFactory.CreateUserDal();
                }
                return _UserDal;
            }

        }


        public IActionDal _ActionDal;
        public IActionDal ActionDal
        {
            get
            {
                if (_ActionDal == null)
                {
                    _ActionDal = AbstractFactory.CreateActionDal();
                }
                return _ActionDal;
            }
        }


        public IPermissionDal _PermissionDal;
        public IPermissionDal PermissionDal
        {
            get
            {
                if (_PermissionDal == null)
                {
                    _PermissionDal = AbstractFactory.CreatePermissionDal();
                }
                return _PermissionDal;
            }
        }

        public bool SaveChange()
        {
            try
            {
                return Db.SaveChanges() > 0;
            }
            catch (DbEntityValidationException ex)
            {
                Console.WriteLine("DbDAL Error: " + ex);
            }
            return false;

        }
    }
}
