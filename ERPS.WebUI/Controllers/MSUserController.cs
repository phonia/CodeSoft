//using EPRS.Service;
//using Microsoft.Practices.Unity;
//using System;
//using System.Collections.Generic;
//using System.Drawing;
//using System.IO;
//using System.Linq;
//using System.Text;
//using System.Web;
//using System.Web.Mvc;

//namespace ERPS.WebUI.Controllers
//{
//    public class MSUserController : BaseController
//    {
//        //
//        // GET: /MSUser/

//        [Dependency]
//        public IUserService _userService { get; set; }

//        public ActionResult Index()
//        {
//            return View();
//        }

//        public JsonResult GetAllMSUser()
//        {
//            //StringBuilder sb = new StringBuilder();
//            //sb.Clear();
//            //sb.Append(_json.Serialize(MSUserService.GetAllMSUser()));
//            //return Content(sb.ToString(), "text/html,charset=UTF-8");
//            //return Json(MSUserService.GetAllMSUser(), JsonRequestBehavior.AllowGet);
//            return null;
//        }

//        [HttpGet]
//        public ActionResult AddUser()
//        {
//            return PartialView();
//        }

//        public ActionResult GetMSUSerInfo(String name)
//        {
//            //return View(MSUserService.GetMSUserByName(name));
//            return null;
//        }

//        //public ActionResult GetUserInfoImage(String name)
//        //{
//        //    MSUserService.GetMSUserByName(name).
//        //}

//        [HttpPost]
//        public JsonResult AddUser(object userPhoto, String userName, String userPwd, int sex, String contactNumber, String email, int userRole)
//        {
//            //MSUserDTO msUserDTO = new MSUserDTO() { Name = userName, Pwd = userPwd, Sex = (SexDTO)sex, ContactNumber = contactNumber, Email = email, MSRole = (MSRoleDTO)userRole };
//            ////var upPhoto = HttpContext.Request.Files.Count;
//            //var upPhoto = HttpContext.Request.Files[0];
//            //if (upPhoto != null)
//            //{
//            //    byte[] data = new byte[upPhoto.ContentLength];
//            //    using (BinaryReader br = new BinaryReader(upPhoto.InputStream, Encoding.UTF8))
//            //    {
//            //        data = br.ReadBytes(upPhoto.ContentLength);
//            //    }
//            //    MSUserService.RegisterUser(msUserDTO, data);
//            //    //return Content(_json.Serialize(new { Success = true }), "text/html,charset=UTF-8");
//            //    return Json(new { Success = true }, JsonRequestBehavior.AllowGet);
//            //}
//            ////return Content(_json.Serialize(new { Success = false }), "text/html,charset=UTF-8");
//            //return Json(new { Success = false }, JsonRequestBehavior.AllowGet);
//            return null;
//        }

//        [HttpGet]
//        public ActionResult Login()
//        {
//            return View();
//        }

//        [HttpPost]
//        public JsonResult Login(String userName, String userPwd)
//        {
//            SUserDTO dto = _userService.Login(userName, userPwd);
//            if (dto == null)
//                return Json(new { Success = false, Message = "登录失败" }, JsonRequestBehavior.AllowGet);
//            else
//            {
//                Session["User"] = dto;
//                return Json(new { Success = true, Message = "登录成功" }, JsonRequestBehavior.AllowGet);
//            }
//        }
//    }
//}
