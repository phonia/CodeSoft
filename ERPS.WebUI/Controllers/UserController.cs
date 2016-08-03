using EPRS.Service;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ERPS.Infrastructure;
using System.IO;
using System.Text;

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

        [Dependency]
        public IMenuInfoService _menuInfoService { get; set; }

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

            String loginName = Request.Form["LoginName"] ?? "";
            String loginPwd = Request.Form["LoginPwd"] ?? "";
            Int32 departmentId = Convert.ToInt32(Request["departmentId"]);
            Int32 positionId = Convert.ToInt32(Request["positionId"]);
            //userPhoto
            //var upPhoto=HttpContext.Request.Files.Count
            byte[] data;
            if (HttpContext.Request.Files.Count > 0)
            {
                var upPhoto = HttpContext.Request.Files[0];
                data = new byte[upPhoto.ContentLength];
                using (BinaryReader br = new BinaryReader(upPhoto.InputStream, Encoding.UTF8))
                {
                    data = br.ReadBytes(upPhoto.ContentLength);
                }
            }
            else
            {
                //默认图片
                data = new byte[10];
            }

            String nName = Request.Form["NName"] ?? "";
            int sex = Convert.ToInt32(Request.Form["sex"]);
            //birthday
            DateTime birthday = Convert.ToDateTime(Request.Form["birthday"]??"");
            String nativePlace = Request.Form["nativePlace"] ?? "";
            String nativeName = Request.Form["nativeName"] ?? "";
            String education = Request.Form["education"] ?? "";
            String graduateCollege = Request.Form["graduateCollege"] ?? "";
            String graduateSpecially = Request.Form["graduateSpecially"] ?? "";
            String tel = Request.Form["tel"] ?? "";
            String mobile = Request.Form["mobile"] ?? "";
            String email = Request.Form["email"] ?? "";
            String qq = Request.Form["qq"] ?? "";
            String msn = Request.Form["msn"] ?? "";
            String address = Request.Form["address"] ?? "";
            String ip = "0.0.0.0";
            String content = Request.Form["content"] ?? "";

            if (_userService.RegisterUser(new SUserDTO()
            {
                CreateTime = DateTime.Now,
                DepartmentId = departmentId,
                DepartmentName = "",
                IsEnable = true,
                IsMultiUser = false,
                IsWork = true,
                LoginCount = 0,
                LoginIp = ip,
                LoginName = loginName,
                LoginPass = loginPwd,
                LoginTime = DateTime.Now,
                OnLineInfo = new OnLineInfoDTO() { 
                    BrowserName=Request.Browser.ToString(),
                    BrowserVersion=Request.Browser.Version,
                    CurrentPage=Request.Url.ToString(),
                    CurrentPageTitle="",
                    IsOnLine=false,
                    OperatingSystem="",
                    SessionId="",
                    TerminalType="0",
                    UserAgent=Request.UserAgent
                },
                PersonInfo = new PersonInfoDTO() {
                    Address=address,
                    Birthday=DateTime.Now,
                    Content=content,
                    Education=(EducationDTO)(Convert.ToInt32(education)),
                    Email=email,
                    GraduateCollege=graduateCollege,
                    GraduateSpecialty=graduateSpecially,
                    Mobile=mobile,
                    Msn=msn,
                    NationalName=nativeName,
                    NativePlace=nativePlace,
                    NName=nName,
                    PhotoImg=data,
                    Qq=qq,
                    Sex=(SexDTO)(Convert.ToInt32(sex)),
                    Tel=tel
                },
                PositionId=positionId,
                PositionName="",
                UpdateTime=DateTime.Now
            }) != null)
            {
                return CustomCheckedResult("用户注册成功", true);
            }
            else
            {
                return CustomCheckedResult("用户注册失败", false);
            }
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

        public JsonResult GetPermission()
        {
            Int32 id = Convert.ToInt32(Request.QueryString["id"]??"-1");
            bool isMenu = Convert.ToInt32(Request.QueryString["isMenu"]??"1")>0;
            bool isMenuPower = Convert.ToInt32(Request.QueryString["isMenuPower"] ?? "1") > 0;
            if (id == -1 && isMenu)
            {
                var list = _menuInfoService.GetMenu(-1, ((SUserDTO)Session["User"]).Id).Select(it => new
                {
                    id = it.Id,
                    text = it.Name,
                    state = "closed",
                    iconCls = "icon-mianmenu",
                    attributes = new { isMenu =1 }
                }).ToList();
                return Json(list, JsonRequestBehavior.AllowGet);
            }
            else
            {
                if (isMenu&&!isMenuPower)
                {
                    var list = _menuInfoService.GetMenu(id, ((SUserDTO)Session["User"]).Id).Select(it => new PermissionDTO()
                    {
                        id = it.Id,
                        text = it.Name,
                        state = "closed",
                        iconCls = "icon-mianmenu",
                        attributes = new attributes() { isMenu = 1 }
                    }).ToList();
                    var node = _userService.GetActionPersionsByMenuId(id).Select(it => new PermissionDTO()
                    {
                        id = it.Id,
                        text = it.ActionSign.GetDescriptionOrNull(),
                        state = "open",
                        iconCls = "icon-leaf",
                        attributes = new attributes() { isMenu = 0 }
                    }).ToList();
                    list.AddRange(node);
                    return Json(list, JsonRequestBehavior.AllowGet);
                }
                if (isMenuPower)
                {
                    var list = _menuInfoService.GetMenu(id, ((SUserDTO)Session["User"]).Id).Select(it => new PermissionDTO()
                    {
                        id = it.Id,
                        text = it.Name,
                        state = "closed",
                        iconCls = "icon-mianmenu",
                        attributes = new attributes() { isMenu = 1 }
                    }).ToList();
                    return Json(list, JsonRequestBehavior.AllowGet);
                }
                return null;
            }
        }
    }
}
