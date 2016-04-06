using ERP.DService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ERP.WebUI.Controllers
{
    public class HomeController : BaseController
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetAccordion()
        {
            List<MSDomainDTO> list = _serviceFactory.GetService<MSUserService>().GetAllDomain();
            return Content(_json.Serialize(
                //new []{
                //    new {url="/Home/GetMenuLeaf?moduleId=UserManager",title="用户管理"},
                //    new {url="/Home/GetMenuLeaf?moduleId=SystemManager",title="系统管理"}
                //}
                list.Select(it => new { url = "/Home/GetMenuLeaf?DomainId=" + it.DomainId, title = it.DomainName }).ToList()
                ),
                "text/html;charset=UTF-8");
        }

        public ActionResult GetMenuLeaf(string DomainId)
        {
            List<MSModuleDTO> list = _serviceFactory.GetService<MSUserService>().GetModuleOfDomain(DomainId);
            return Content(_json.Serialize(
                //new []{
                //    new {url="http://www.baidu.com",title="baidu"},
                //    new {url="http://www.tudou.com",title="tudou"}
                //}
                list.Select(it=>new {url=it.ModuleUrl,title=it.ModuleName}).ToList()
                ),
                "text/html;charset=UTF-8");
        }

    }
}
