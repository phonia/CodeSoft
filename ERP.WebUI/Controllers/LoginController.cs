using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ERP.DService;
using System.Web.Script.Serialization;
using System.Text;

namespace ERP.WebUI.Controllers
{
    public class LoginController : BaseController
    {
        //private JavaScriptSerializer json = new JavaScriptSerializer();
        //
        // GET: /Login/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login(string UserName,string UserPwd)
        {
            MSUserService service = _serviceFactory.GetService<MSUserService>();
            if (service.Login(UserName, UserPwd))
            {
                Session["userName"] = UserName;
                //return RedirectToAction("Index", "Home");
                return Content(_json.Serialize(new{ Success=true,Message="登录成功"}), "text/html;charset=UTF-8");
            }
            else
            {
                return Content(_json.Serialize(new { Success = false, Message = "登录失败" }), "text/html;charset=UTF-8");
            }
        }

        public ActionResult GelAllRoles()
        {
            MSUserService service = _serviceFactory.GetService<MSUserService>();
            List<MSRoleDTO> roles=service.GetAllMSRoles();
            return Content(_json.Serialize(roles).ToString(), "text/html,charset=UTF-8");
        }

        public ActionResult RegisterUser(string userName,string userPwd,string roleName)
        {
            MSUserService service = _serviceFactory.GetService<MSUserService>();
            MSUserDTO user = new MSUserDTO() { UserName = userName, Passworld = userPwd, RoleName = roleName };
            service.RegisterMSUser(user);
            Session["userName"] = userName;
            //return RedirectToAction("Index", "Home");
            return Content(_json.Serialize(new { Success = false, Message = "注册成功" }), "text/html;charset=UTF-8");
        }

    }
}
