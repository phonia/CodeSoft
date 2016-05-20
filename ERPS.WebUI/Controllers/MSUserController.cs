using EPRS.Service;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace ERPS.WebUI.Controllers
{
    public class MSUserController : BaseController
    {
        //
        // GET: /MSUser/

        [Dependency]
        public IMSUserService MSUserService { get; set; }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetAllMSUser()
        {
            StringBuilder sb = new StringBuilder();
            sb.Clear();
            sb.Append(_json.Serialize(MSUserService.GetAllMSUser()));
            return Content(sb.ToString(), "text/html,charset=UTF-8");
        }

        [HttpGet]
        public ActionResult AddUser()
        {
            return PartialView();
        }

        [HttpPost]
        public ActionResult AddUser(object userPhoto,String userName,String userPwd,String sex,String contactNumber,String email,String userRole)
        {
            var upPhoto = HttpContext.Request.Files.Count;
            return null;
        }

    }
}
