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
        //[Dependency]
        //public IMSUserService MSUserService { get; set; }
        [Dependency]
        public IMenuInfoService _menuInfoService { get; set; }
        [Dependency]
        public IUserService _userService { get; set; }
        //
        // GET: /Home/
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetMenu(String id)
        {
            List<MenuInfoDTO> menus= _menuInfoService.GetMenu(Convert.ToInt32(id),((SUserDTO)Session["User"]).Id);
            return Json(new
            {
                Success = true,
                Data = menus.Select(it => new { Url =it.IsMenu==true? "/Home/GetMenu?id=" + it.Id:it.Url, Title = it.Name }),
            },JsonRequestBehavior.AllowGet);
        }
    }
}
