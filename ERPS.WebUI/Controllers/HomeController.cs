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

        public JsonResult GetMainMenu()
        {
            return Json(new
            {
                Success = true,
                Data = new[]{
                    new {Url="/Home/GetSecondaryMenu?mainId=PersonalDuty",Title="个人事务"},
                    new {Url="/Home/GetSecondaryMenu?mainId=InfoManager",Title="信息管理"},
                    new {Url="/Home/GetSecondaryMenu?mainId=EmployeerManager",Title="员工管理"},
                    new {Url="/Home/GetSecondaryMenu?mainId=BaseSetting",Title="基本设置"},
                    new {Url="/Home/GetSecondaryMenu?mainId=AuthorityManagement",Title="权限管理"},
                    new {Url="/Home/GetSecondaryMenu?mainId=SecurityManagement",Title="安全管理"}
                }
            },JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetSecondaryMenu(String mainId)
        {
            switch (mainId)
            {
                case "PersonalDuty": return Json(new
                {
                    Success = true,
                    Data = new[]{
                    new {Url="/MSUser",Title="个人设置"},
                    new {Url="/MSUser",Title="部门通讯录"},
                    new {Url="/MSUser",Title="公司通讯录"}
                }
                }, JsonRequestBehavior.AllowGet);
                case "InfoManager": return Json(new
                {
                    Success = true,
                    Data = new[]{
                    new {Url="/MSUser",Title="信息分类管理"},
                    new {Url="/MSUser",Title="信息内容管理"},
                    new {Url="/MSUser",Title="邮件信息管理"}
                }
                }, JsonRequestBehavior.AllowGet);
                case "EmployeerManager": return Json(new
                {
                    Success = true,
                    Data = new[]{
                    new {Url="/MSUser",Title="在职人员"},
                    new {Url="/MSUser",Title="离职人员"}
                }
                }, JsonRequestBehavior.AllowGet);
                case "BaseSetting": return Json(new
                {
                    Success = true,
                    Data = new[]{
                    new {Url="/MSUser",Title="基本参数设置"},
                    new {Url="/MSUser",Title="重新生成图片"}
                }
                }, JsonRequestBehavior.AllowGet);
                case "AuthorityManagement": return Json(new
                {
                    Success = true,
                    Data = new[]{
                    new {Url="/MSUser",Title="菜单管理"},
                    new {Url="/MSUser",Title="页面按键名称设置"},
                    new {Url="/MSUser",Title="页面权限设置"},
                    new {Url="/MSUser",Title="部门管理"},
                    new {Url="/MSUser",Title="职位管理"}
                }
                }, JsonRequestBehavior.AllowGet);
                case "SecurityManagement": return Json(new
                {
                    Success = true,
                    Data = new[]{
                    new {Url="/MSUser",Title="在线用户"},
                    new {Url="/MSUser",Title="登录日志"},
                    new {Url="/MSUser",Title="操作日志"}
                    ,new {Url="/MSUser",Title="错误日志"}
                }
                }, JsonRequestBehavior.AllowGet);
                default: return null;
            }
        }

    }
}
