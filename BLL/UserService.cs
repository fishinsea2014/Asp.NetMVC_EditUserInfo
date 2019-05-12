using BLL.IBLL;
using DAL;
using DataSource;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class UserService : BaseService<User>, IUserService
    {
        public override void SetCurrentDal()
        {
            CurrentDal = this.GetCurrentDbSession.UserDal;
        }
    }
}
