using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public interface IDBSession
    {
        bool SaveChange();
        Interface.IUserDal UserDal { get; }
        Interface.IActionDal ActionDal { get; }
        Interface.IPermissionDal PermissionDal { get; }
    }
}
