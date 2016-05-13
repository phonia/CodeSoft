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
    public class HomeController : BaseController
    {
        [Dependency]
        public IMSUserService MSUserService { get; set; }
        //
        // GET: /Home/
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetMainMenu()
        {
            Session["MSUserDTO"] = new MSUserDTO() { Name = "hy" };
            return Content(_json.Serialize(new{
                Success=true,
               Data=new []{
                    new {Url="/Home/GetSecondaryMenu?mainId=SysManger",Title="系统管理"}
                }
            }),
                "text/html;charset=UTF-8");
        }

        public ActionResult GetSecondaryMenu(String mainId)
        {
            StringBuilder sb = new StringBuilder();
            sb.Clear();
            if (mainId.Equals("SysManger"))
            {
                sb.Append(_json.Serialize(new
                {
                    Success = true,
                    Data = new[]{
                    new {Url="/MSUser",Title="用户管理"}
                }
                }));
            }
            return Content(sb.ToString(), "text/html;charset=UTF-8");
        }

    }
}
