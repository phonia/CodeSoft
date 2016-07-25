using EPRS.Service;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ERPS.WebUI.Controllers
{
    public class UserController : BaseController
    {
        //
        // GET: /User/

        [Dependency]
        public IUserService _userService { get; set; }

        [Dependency]
        public IAppInstallService _IntallService { get; set; }

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Login()
        {
            _IntallService.Install();
            return View();
        }

        [HttpPost]
        public JsonResult Login(String userName, String userPwd)
        {
            SUserDTO dto = _userService.Login(userName, userPwd);
            if (dto == null)
                return Json(new { Success = false, Message = "登录失败" }, JsonRequestBehavior.AllowGet);
            else
            {
                Session["User"] = dto;
                return Json(new { Success = true, Message = "登录成功" }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpGet]
        public ActionResult GetAllUserView()
        {
            return View();
        }

        [HttpPost]
        public JsonResult GetAllUserAction()
        {
            List<SUserDTO> users = _userService.GetUsers();
            return Json(users, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult GetRegisterUserView()
        {
            return View();
        }

    }
}
