using EPRS.Service;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ERPS.Infrastructure;

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

        [HttpPost]
        public ActionResult GetRegisterUserAction()
        {

            return null;
        }

        [HttpGet]
        public JsonResult GetSex()
        {
            return Json(new[] { 
                new {Value=SexDTO.Female,Text=SexDTO.Female.GetDescriptionOrNull()??""},
                new {Value=SexDTO.Male,Text=SexDTO.Male.GetDescriptionOrNull()??""},
                new {Value=SexDTO.Unknown,Text=SexDTO.Unknown.GetDescriptionOrNull()??""}
            }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult GetEducation()
        {
            return Json(new []{
                new {Value=EducationDTO.MiddleSchool,Text=EducationDTO.MiddleSchool.GetDescriptionOrNull()??""},
                new {Value=EducationDTO.University,Text=EducationDTO.University.GetDescriptionOrNull()??""},
                new {Value=EducationDTO.Unknown,Text=EducationDTO.Unknown.GetDescriptionOrNull()??""},
                new {Value=EducationDTO.VUniversity,Text=EducationDTO.VUniversity.GetDescriptionOrNull()??""}
            },JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult GetDepartmentsView()
        {
            return View();
        }

        public JsonResult GetDepartmentsAction()
        {
            List<DepartmentDTO> departments = _userService.GetDepartments();
            return Json(departments, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult GetRegisterDepartmentView()
        {
            return PartialView();
        }

        [HttpPost]
        public JsonResult GetRegisterDepartmentAction()
        {
            String departmentName = Request.Form["name"] ?? "";
            String departmentNotes = Request.Form["note"] ?? "";
            String departmentCode = Request.Form["code"] ?? "";
            DepartmentDTO department= _userService.RegisterDepartment(new DepartmentDTO() {
                Name=departmentName,
                Notes=departmentNotes
            },departmentCode);
            return Json(new
            {
                Success = true,
                Message = "注册成功"
            }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult RemoveDepartmentAction(string del)
        {
            if (String.IsNullOrWhiteSpace(del))
                return Json(new
                {
                    Success = false,
                    Message = "没有获得删除行"
                }, JsonRequestBehavior.AllowGet);
            else
            {
                var ids = del.Split(',');
                var list = ids.Select(it => Convert.ToInt32(it)).ToList();
                if (_userService.RemoveDepartment(list))
                {
                    return Json(new
                    {
                        Success = true,
                        Message = "删除成功"
                    }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(new
                    {
                        Success = false,
                        Message = "删除失败"
                    }, JsonRequestBehavior.AllowGet);
                }
            }
        }

        [HttpGet]
        public ActionResult GetPositionsView()
        {
            return View();
        }

        public JsonResult GetPositionsAction()
        {
            if (Request.QueryString["departmentId"] != null)
                return Json(_userService.GetPositions()
                    .Where(it => it.DepartmentId.ToString().Equals(Request.QueryString["departmentId"].ToString())).ToList(),
                    JsonRequestBehavior.AllowGet);
            else
            {
                return Json(_userService.GetPositions(), JsonRequestBehavior.AllowGet);
            }
        }

        [HttpGet]
        public ActionResult GetRegisterPositionView()
        {
            return PartialView();
        }

        public JsonResult GetRegisterPositionAction()
        {
            String positionName = Request.Form["name"] ?? "";
            String positionPagePower = Request.Form["pagePower"] ?? "";
            String positionControlPower = Request.Form["controlPower"] ?? "";
            String PositionDepartmentId = Request.Form["departmentId"] ?? "";
            _userService.RegisterPosition(new PositionDTO() { 
                ControlPower=positionControlPower,
                DepartmentId=Convert.ToInt32(PositionDepartmentId),
                Name=positionName,
                PagePower=positionPagePower,
                UpdateDate=DateTime.Today
            });
            return Json(new
            {
                Success = true,
                Message = "注册成功"
            }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult RemovePositionAction(String del)
        {
            if (String.IsNullOrWhiteSpace(del))
                return Json(new
                {
                    Success = false,
                    Message = "没有获得数据"
                }, JsonRequestBehavior.AllowGet);
            else
            {
                if (_userService.RemovePosition(del.Split(',').Select(it => Convert.ToInt32(it)).ToList()))
                {
                    return Json(new
                    {
                        Success = true,
                        Message = "删除成功"
                    }, JsonRequestBehavior.AllowGet);
                }
                else
                    return Json(new
                    {
                        Success = false,
                        Message = "删除失败"
                    }, JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult UpdatePositionsAction()
        {
            return null;
        }
    }
}
