using EPRS.Service;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
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

    }
}
