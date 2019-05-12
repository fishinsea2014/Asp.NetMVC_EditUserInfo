using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace DALFactory
{
    public class DBSessionFactory
    {
        public static IDBSession CreateDbSession()
        {
            IDBSession dbSession = (IDBSession)CallContext.GetData("dbSession");

            if (dbSession == null)
            {
                dbSession = new DALFactory.DBSession();
                CallContext.SetData("dbSession", dbSession);
            }

            return dbSession;

        }
    }
}
