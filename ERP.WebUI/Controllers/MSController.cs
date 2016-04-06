using ERP.DService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ERP.WebUI.Controllers
{
    public class MSController : BaseController
    {
        //
        // GET: /MS/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult RoleManager()
        {
            return View();
        }

        public ActionResult UserManager()
        {
            return View();
        }

        public ActionResult LoadRoles()
        {
            MSUserService service = _serviceFactory.GetService<MSUserService>();

            return Content(_json.Serialize(service.GetAllMSRoles()), "text/html,charset=UTF-8");
        }

        public ActionResult GetAllModules()
        {
            List<MSModuleDTO> list = _serviceFactory.GetService<MSUserService>().GetAllModule();
            return Content(_json.Serialize(
                list
                ),
                "text/html;charset=UTF-8");
        }

        public ActionResult GetRightsOfModule(string moduleId)
        {
            MSUserService service = _serviceFactory.GetService<MSUserService>();
            List<MSRightDTO> list = service.GetRightsOfModule(moduleId);
            return Content("", "text/html;charset=UTF-8");
        }

        public ActionResult GetAllRights()
        {
            MSUserService service = _serviceFactory.GetService<MSUserService>();
            List<MSRightDTO> list = service.GetAllRights();
            return Content(_json.Serialize(list), "text/html;charset=UTF-8");
        }

    }
}
