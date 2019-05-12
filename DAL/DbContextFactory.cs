using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Remoting.Messaging;
using DataSource;

namespace DAL
{
    public class DbContextFactory
    {
        public static DbContext CreateContext()
        {
            DbContext dbContext = (DbContext)CallContext.GetData("dbContext");
            if (dbContext == null)
            {
                dbContext = new UsersContainer();
                CallContext.SetData("dbContext", dbContext);
            }
            return dbContext;
        }
    }
}
