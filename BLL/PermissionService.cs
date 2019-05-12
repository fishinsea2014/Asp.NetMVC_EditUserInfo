﻿using BLL.IBLL;
using DataSource;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class PermissionService : BaseService<Permission>, IPermissionService
    {
        public override void SetCurrentDal()
        {
            CurrentDal = this.GetCurrentDbSession.PermissionDal;
        }
    }
}
