using DataSource;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyProfile.Controllers
{
    public class HomeController : Controller
    {
        private User _user ;
        private List<Actions> _actions;
        private List<Permission> _permissions;

        public BLL.IBLL.IUserService userService = new BLL.UserService();
        public BLL.IBLL.IActionService actionService = new BLL.ActionService();
        public BLL.IBLL.IPermissionService permissionService = new BLL.PermissionService();

        public HomeController()
        {
            InitData();
        }
        public void InitData()
        {
            if (userService.LoadEntities(u => true).Count() == 0)
            {
                User user=new User()
                {
                    Id = 0,
                    FName = "Richard",
                    LName = "Holmes",
                    Password = "123",
                    TimeZone = "Auckland",
                    Title = "Managing Director",
                    OrgName="Health & Safety Warden"
                };
                userService.AddEntity(user);
                actionService.SaveChanges();

            }

            if (actionService.LoadEntities(u => true).Count() == 0)
            {
                Actions act1 = new Actions() { Id = 0, ActionName = "General" };
                Actions act2 = new Actions() { Id = 1, ActionName = "OA Project" };
                Actions act3 = new Actions() { Id = 2, ActionName = "Finance Project" };
                actionService.AddEntity(act1);
                actionService.AddEntity(act2);
                actionService.AddEntity(act3);
                actionService.SaveChanges();
            }

            

            //permissionService.AddEntity(new Permission() { Id = 0, UserId = 0, ActionId = 0, Status = 0 });
            //permissionService.SaveChanges();

        }

        public ActionResult Index(int ?id)
        {
            User curUser = userService.LoadEntities(u => true).FirstOrDefault();
            return View(curUser);
        }

        public ActionResult Init()
        {
            var res = new
            {
                user=_user,
                actions=_actions.ToList(),
                permissions=_permissions.ToList()
            };

            return Json(res, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult UpdateName(User user)
        {
            if (userService.EditEntity(user))
            {
                return Content("ok");
            }
            else
            {
                return Content("failed");
            }
        }



        #region Useless 
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        } 
        #endregion
    }
}