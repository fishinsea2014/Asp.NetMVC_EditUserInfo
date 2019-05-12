using DataSource;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.IBLL
{
    public partial interface IUserService : IBaseService<User>{ }
    public partial interface IActionService: IBaseService<Actions> { }
    public partial interface IPermissionService : IBaseService<Permission> { }

}
