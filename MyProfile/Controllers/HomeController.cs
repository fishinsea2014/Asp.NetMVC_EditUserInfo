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
            //TimeZoneInfo timeZoneInfo

            

            //permissionService.AddEntity(new Permission() { Id = 0, UserId = 0, ActionId = 0, Status = 0 });
            //permissionService.SaveChanges();

        }

        public ActionResult Index(int ?id)
        {
            User curUser = userService.LoadEntities(u => true).FirstOrDefault();
            var timezoneList = TimeZoneInfo.GetSystemTimeZones()
                                .Select(t => new SelectListItem
                                {
                                    Text = t.DisplayName,
                                    Value = t.Id,
                                    Selected = t.Id==curUser.DefaultTimeZoneId
                                });
            ViewBag.timezoneList = timezoneList;

            ViewBag.AllActions = actionService.LoadEntities(u => true).ToList();
            ViewBag.CurUserActions = permissionService.LoadEntities(r => r.UserId == curUser.Id)
                                    .ToList();            

            //Todo: return actions with a viewbag
            

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
                var userInfo = new
                {
                    FName = user.FName,
                    LName = user.LName,
                    Title = user.Title,
                    Org = user.OrgName

                };
                return Json(userInfo);
            }
            else
            {
                return Content("failed");
            }
        }

        [HttpPost]
        public ActionResult ChangePwd()
        {
            int id = int.Parse(Request.Form["Id"]);
            var user = userService.LoadEntities(u => u.Id == id).FirstOrDefault();
            var prePwd = Request.Form["prePwd"];
            var newPwd = Request.Form["newPwd"];
            if (user.Password == prePwd)
            {
                user.Password = newPwd;
                userService.EditEntity(user);
                return Content("ok");
            }
            else
            {
                return Content("Invalid previous password");
            }
            //var newPwd1 = Request["newPwd"];
        }

        [HttpPost]
        public ActionResult UpdateTimezone()
        {
            int userId = int.Parse(Request.Form["Id"]);
            var isDefault = Request.Form["set-default-timezone"]; //is 'on' if checked
            var newTimezone = Request.Form["timezone-dropdownlist"]; //A timezone string

            var user = userService.LoadEntities(u => u.Id == userId).FirstOrDefault();
            user.TimeZoneId = newTimezone;
            if (isDefault == "on")
            {
                user.DefaultTimeZoneId = newTimezone;
            }
            if (userService.EditEntity(user))
            {
                return Content("ok");
            }
            else
            {
                return Content("Failed to update timezone.");
            }
            //TODO update timezone and default timezone.

        }

        public ActionResult SetPermission()
        {
            //TODO: 接收ID和结果，变更数据
            var actionId = int.Parse(Request.Form["actionId"]);
            var permissionRes = int.Parse(Request.Form["permission"]);
            var userId = int.Parse(Request.Form["userId"]);
            var curPermission = permissionService.LoadEntities(
                                 p => p.UserId == userId && p.ActionId == actionId)
                                 .FirstOrDefault();
            if (curPermission == null)
            {
                Permission newPermission = new Permission()
                {
                    ActionId = actionId,
                    Status = (short)permissionRes,
                    UserId = userId
                };
                permissionService.AddEntity(newPermission);
            }
            else
            {
                curPermission.Status = (short)permissionRes;
                permissionService.EditEntity(curPermission);
            }
            
            
            return Redirect("Index");
        }

        public ActionResult Error()
        {
            return View();
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