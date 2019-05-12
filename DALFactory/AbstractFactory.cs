using DAL;
using DAL.Interface;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DALFactory
{
    public class AbstractFactory
    {
        private readonly static string DalAssemblyPath = ConfigurationManager.AppSettings["DalAssemblyPath"];
        private readonly static string NameSpace = ConfigurationManager.AppSettings["NameSpace"];


        /// <summary>
        /// Utilise reflection to create relevant instance
        /// </summary>
        /// <param name="fullClassName"></param>
        /// <returns></returns>
        public static object CreateInstance(string fullClassName)
        {
            var assembly = Assembly.Load(DalAssemblyPath);
            return assembly.CreateInstance(fullClassName);
        }

        public static IUserDal CreateUserDal()
        {
            //Construct a full name of class by namesapce and full name
            string fullClassName = NameSpace + ".UserDal";
            return CreateInstance(fullClassName) as IUserDal;
        }

        public static IActionDal CreateActionDal()
        {
            //Construct a full name of class by namesapce and full name
            string fullClassName = NameSpace + ".ActionDal";
            return CreateInstance(fullClassName) as IActionDal;
        }

        public static IPermissionDal CreatePermissionDal()
        {
            //Construct a full name of class by namesapce and full name
            string fullClassName = NameSpace + ".PermissionDal";
            return CreateInstance(fullClassName) as IPermissionDal;
        }
    }
}
