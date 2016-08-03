using ERPS.Models;
using Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EPRS.Service
{
    public class AppInstall:IAppInstallService
    {
        IUnitOfWork _unitOfWork = null;
        IMenuInfoRepository _menuInfoRepository = null;
        IWebConfigRepository _webConfigRepository = null;
        ISUserRepository _suserRepository = null;
        IPositionRepository _positoryRepository = null;
        IDepartmentRepository _departmentRepository = null;

        public AppInstall(IUnitOfWork unitOfWork,
            IMenuInfoRepository menuInfoRepositry,IWebConfigRepository webConfigRepository,
            ISUserRepository suserRepository,IPositionRepository positoryRepository,IDepartmentRepository departmentRepository)
        {
            _unitOfWork = unitOfWork;
            _menuInfoRepository = menuInfoRepositry;
            _webConfigRepository = webConfigRepository;
            _suserRepository = suserRepository;
            _positoryRepository = positoryRepository;
            _departmentRepository = departmentRepository;

            _positoryRepository.UnitOfWork = unitOfWork;
            _menuInfoRepository.UnitOfWork = unitOfWork;
            _webConfigRepository.UnitOfWork = unitOfWork;
            _suserRepository.UnitOfWork = unitOfWork;
            _positoryRepository.UnitOfWork = unitOfWork;
            _departmentRepository.UnitOfWork = unitOfWork;
        }

        public void Install()
        {
            //if (_PagePowerSignRepository.GetAll().Count() <= 0)
            //{
            //    var pagePowers = new List<PagePowerSign>() { 
            //        new PagePowerSign(){CName="查看",EName="LookOver"},
            //        new PagePowerSign(){CName="查询",EName="LookFor"},
            //        new PagePowerSign(){CName="编辑",EName="Edit"},
            //        new PagePowerSign(){CName="报表",EName="Report"},
            //        new PagePowerSign(){CName="删除",EName="Remove"},
            //        new PagePowerSign(){CName="审核",EName="Adulting"},
            //        new PagePowerSign(){CName="反审核",EName="UnAdulting"}
            //    };

            //    foreach (var node in pagePowers)
            //    {
            //        _PagePowerSignRepository.Add(node);
            //    }
            //}

            if (_menuInfoRepository.GetAll().Count() <= 0)
            {
                //var menus = new List<MenuInfo>() { 
                //    new MenuInfo(){Depth=1,IsDisplay=true,IsMenu=true,Name="个人事务",Url="",Sort=0,MenuInfos=new List<MenuInfo>(){
                //        new MenuInfo(){Depth=2,IsDisplay=true,IsMenu=false,Name="个人设置",Url="\\User\\GetUserSetting",Sort=0},
                //        new MenuInfo(){Depth=2,IsDisplay=true,IsMenu=false,Name="部门通讯录",Url="\\User\\GetUserWithDepartment",Sort=0},
                //        new MenuInfo(){Depth=2,IsDisplay=true,IsMenu=false,Name="公司通讯录",Url="\\User\\GetAllUser",Sort=0}
                //    }},
                //    new MenuInfo(){Depth=1,IsDisplay=true,IsMenu=true,Name="信息管理",Url="",Sort=0,MenuInfos=new List<MenuInfo>(){
                //        new MenuInfo(){Depth=2,IsDisplay=true,IsMenu=false,Name="信息分类管理",Url="",Sort=0},
                //        new MenuInfo(){Depth=2,IsDisplay=true,IsMenu=false,Name="信息内容管理",Url="",Sort=0},
                //        new MenuInfo(){Depth=2,IsDisplay=true,IsMenu=false,Name="邮件信息管理",Url="",Sort=0}
                //    }},
                //    new MenuInfo(){Depth=1,IsDisplay=true,IsMenu=true,Name="员工管理",Url="",Sort=0,MenuInfos=new List<MenuInfo>(){
                //        new MenuInfo(){Depth=2,IsDisplay=true,IsMenu=false,Name="在职人员",Url="\\User\\GetUserPayroll",Sort=0},
                //        new MenuInfo(){Depth=2,IsDisplay=true,IsMenu=false,Name="离职人员",Url="\\User\\GetUserDismission",Sort=0},
                //        new MenuInfo(){Depth=2,IsDisplay=true,IsMenu=false,Name="员工注册",Url="\\User\\RegisterUser",Sort=0}
                //    }},
                //    new MenuInfo(){Depth=1,IsDisplay=true,IsMenu=true,Name="基本设置",Url="",Sort=0,MenuInfos=new List<MenuInfo>(){
                //        new MenuInfo(){Depth=2,IsDisplay=true,IsMenu=false,Name="基本参数设置",Url="",Sort=0},
                //        new MenuInfo(){Depth=2,IsDisplay=true,IsMenu=false,Name="重新生成图片",Url="",Sort=0}  
                //    }},
                //    new MenuInfo(){Depth=1,IsDisplay=true,IsMenu=true,Name="权限管理",Url="",Sort=0,MenuInfos=new List<MenuInfo>(){
                //        new MenuInfo(){Depth=2,IsDisplay=true,IsMenu=false,Name="菜单管理",Url="\\MenuInfo\\GetMenuInfos",Sort=0,MenuInfos=new List<MenuInfo>(){
                //            new MenuInfo(){Depth=3,IsDisplay=false,IsMenu=false,Name="菜单添加",Url="\\MenuInfo\\AddMenuInfo",Sort=0},
                //            new MenuInfo(){Depth=3,IsDisplay=false,IsMenu=false,Name="菜单修改",Url="\\MenuInfo\\SaveMenuInfo",Sort=0},
                //            new MenuInfo(){Depth=3,IsDisplay=false,IsMenu=false,Name="菜单删除",Url="\\MenuInfo\\DeleteMenuInfo",Sort=0}
                //        }},
                //        new MenuInfo(){Depth=2,IsDisplay=true,IsMenu=false,Name="页面权限",Url="\\MenuInfo\\GetPagePowerSigns",Sort=0},
                //        new MenuInfo(){Depth=2,IsDisplay=true,IsMenu=false,Name="部门管理",Url="\\User\\GetDepartments",Sort=0},
                //        new MenuInfo(){Depth=2,IsDisplay=true,IsMenu=false,Name="职位管理",Url="\\User\\GetPositions",Sort=0}
                //    }},
                //    new MenuInfo(){Depth=1,IsDisplay=true,IsMenu=true,Name="安全管理",Url="",Sort=0,MenuInfos=new List<MenuInfo>(){
                //        new MenuInfo(){Depth=2,IsDisplay=true,IsMenu=false,Name="操作日志",Url="",Sort=0},
                //        new MenuInfo(){Depth=2,IsDisplay=true,IsMenu=false,Name="错误日志",Url="",Sort=0},
                //        new MenuInfo(){Depth=2,IsDisplay=true,IsMenu=false,Name="在线用户",Url="",Sort=0}
                //    }}
                //};

                var menus = new List<MenuInfo>() { 
                    new MenuInfo(){Depth=1,IsDisplay=true,IsMenu=true,Name="用户管理",Url="",Sort=0,MenuInfos=new List<MenuInfo>(){
                        new MenuInfo(){Depth=2,IsDisplay=true,IsMenu=false,Name="用户列表",Url="\\User\\GetAllUserView",Sort=0,ActionPermissions=new List<ActionPermission>(){
                            new ActionPermission(){ActionSign=ActionSign.Abandon,Sort=0,Url=""},
                            new ActionPermission(){ActionSign=ActionSign.Delete,Sort=0,Url="\\User\\RemoveUserAction"},
                            new ActionPermission(){ActionSign=ActionSign.Recovery,Sort=0,Url=""},
                            new ActionPermission(){ActionSign=ActionSign.Review,Sort=0,Url=""},
                            new ActionPermission(){ActionSign=ActionSign.Search,Sort=0,Url="\\User\\GetAllUserAction"},
                            new ActionPermission(){ActionSign=ActionSign.UnReview,Sort=0,Url=""},
                            new ActionPermission(){ActionSign=ActionSign.Update,Sort=0,Url="\\User\\UpdateUserAction"},
                            new ActionPermission(){ActionSign=ActionSign.LookOver,Sort=0,Url="\\GetUserAction"}
                        }},
                        new MenuInfo(){Depth=2,IsDisplay=true,IsMenu=false,Name="用户注册",Url="\\User\\GetRegisterUserView",Sort=0,ActionPermissions=new List<ActionPermission>(){
                            new ActionPermission(){ActionSign=ActionSign.Create,Sort=0,Url="\\User\\GetRegisterUserAction"},
                        }}
                    }},
                    new MenuInfo(){Depth=1,IsDisplay=true,IsMenu=true,Name="权限管理",Url="",Sort=0,MenuInfos=new List<MenuInfo>(){
                        new MenuInfo(){Depth=2,IsDisplay=true,IsMenu=false,Name="页面权限",Url="\\User\\GetActionPermissionView",Sort=0,ActionPermissions=new List<ActionPermission>(){
                            new ActionPermission(){ActionSign=ActionSign.Abandon,Sort=0,Url=""},
                            new ActionPermission(){ActionSign=ActionSign.Create,Sort=0,Url=""},
                            new ActionPermission(){ActionSign=ActionSign.Delete,Sort=0,Url=""},
                            new ActionPermission(){ActionSign=ActionSign.Recovery,Sort=0,Url=""},
                            new ActionPermission(){ActionSign=ActionSign.Review,Sort=0,Url=""},
                            new ActionPermission(){ActionSign=ActionSign.Search,Sort=0,Url=""},
                            new ActionPermission(){ActionSign=ActionSign.UnReview,Sort=0,Url=""},
                            new ActionPermission(){ActionSign=ActionSign.Update,Sort=0,Url=""},
                            new ActionPermission(){ActionSign=ActionSign.LookOver,Sort=0,Url=""}
                        }},
                        new MenuInfo(){Depth=2,IsDisplay=true,IsMenu=false,Name="部门管理",Url="\\User\\GetDepartmentsView",Sort=0,ActionPermissions=new List<ActionPermission>(){
                            new ActionPermission(){ActionSign=ActionSign.Abandon,Sort=0,Url=""},
                            new ActionPermission(){ActionSign=ActionSign.Create,Sort=0,Url="\\User\\GetRegisterDepartmentAction"},
                            new ActionPermission(){ActionSign=ActionSign.Delete,Sort=0,Url="\\User\\RemoveDepartmentAction"},
                            new ActionPermission(){ActionSign=ActionSign.Recovery,Sort=0,Url=""},
                            new ActionPermission(){ActionSign=ActionSign.Review,Sort=0,Url=""},
                            new ActionPermission(){ActionSign=ActionSign.Search,Sort=0,Url="\\User\\GetDepartmentsAction"},
                            new ActionPermission(){ActionSign=ActionSign.UnReview,Sort=0,Url=""},
                            new ActionPermission(){ActionSign=ActionSign.Update,Sort=0,Url="\\User\\UpdateDepartmentAction"},
                            new ActionPermission(){ActionSign=ActionSign.LookOver,Sort=0,Url="\\User\\GetDepartmentAction"}
                        }},
                        new MenuInfo(){Depth=2,IsDisplay=true,IsMenu=false,Name="职位管理",Url="\\User\\GetPositionsView",Sort=0,ActionPermissions=new List<ActionPermission>(){
                            new ActionPermission(){ActionSign=ActionSign.Abandon,Sort=0,Url=""},
                            new ActionPermission(){ActionSign=ActionSign.Create,Sort=0,Url="\\User\\GetRegisterPositionAction"},
                            new ActionPermission(){ActionSign=ActionSign.Delete,Sort=0,Url="\\User\\RemovePositionAction"},
                            new ActionPermission(){ActionSign=ActionSign.Recovery,Sort=0,Url=""},
                            new ActionPermission(){ActionSign=ActionSign.Review,Sort=0,Url=""},
                            new ActionPermission(){ActionSign=ActionSign.Search,Sort=0,Url="\\User\\GetPositionsAction"},
                            new ActionPermission(){ActionSign=ActionSign.UnReview,Sort=0,Url=""},
                            new ActionPermission(){ActionSign=ActionSign.Update,Sort=0,Url="\\User\\UpdatePositionsAction"},
                            new ActionPermission(){ActionSign=ActionSign.LookOver,Sort=0,Url="\\User\\GetPositionAction"}
                        }},
                    }},
                    new MenuInfo(){Depth=1,IsDisplay=true,IsMenu=true,Name="基本设置",Url="",Sort=0,MenuInfos=new List<MenuInfo>(){
                        new MenuInfo(){Depth=2,IsDisplay=true,IsMenu=false,Name="基本信息",Url="\\WebConfig\\GetSettingsView",Sort=0}
                    }},
                    new MenuInfo(){Depth=1,IsDisplay=true,IsMenu=true,Name="安全管理",Url="",Sort=0,MenuInfos=new List<MenuInfo>(){
                        new MenuInfo(){Depth=2,IsDisplay=true,IsMenu=false,Name="在线用户",Url="\\User\\RegisterUser",Sort=0},
                        new MenuInfo(){Depth=2,IsDisplay=true,IsMenu=false,Name="用户日志",Url="\\User\\RegisterUser",Sort=0},
                        new MenuInfo(){Depth=2,IsDisplay=true,IsMenu=false,Name="错误日志",Url="\\User\\RegisterUser",Sort=0}
                    }}
                };

                

                foreach (var node in menus)
                {
                    _menuInfoRepository.Add(node);
                }

                if (_suserRepository.GetAll().Count() <= 0)
                {
                    //未完成

                    var department = new Department()
                    {
                        Code = "1",
                        Depth = 0,
                        Name = "超级管理员",
                        Notes = "后台管理",
                        Sort = 0,
                        UpdateDate=DateTime.Now
                    };

                    var suser = new SUser()
                    {
                        CreateTime = DateTime.Today,
                        IsEnable = true,
                        IsMultiUser = false,
                        IsWork = true,
                        LoginCount = 0,
                        LoginIp = "0",
                        LoginName = "Admin",
                        LoginPass = "Admin",
                        LoginTime = DateTime.Today,
                        OnLineInfo = new OnLineInfo() 
                        {
                            BrowserName="",
                            BrowserVersion="",
                            CurrentPage="",
                            CurrentPageTitle="",
                            IsOnLine=false,
                            OperatingSystem="Win7",
                            SessionId="",
                            TerminalType="0",
                            UserAgent=""
                        },
                        PersonInfo = new PersonInfo() { 
                            Address="",
                            Birthday=DateTime.Today,
                            Content="",
                            Education=Education.University,
                            Email="hy@turingit.com",
                            GraduateCollege="",
                            GraduateSpecialty="",
                            Mobile="",
                            Msn="",
                            NationalName="",
                            NativePlace="",
                            NName="",
                            PhotoImg=new byte[10],
                            Qq="",
                            Sex=Sex.Unknown,
                            Tel=""
                        },
                        Position = new Position() { 
                            ControlPower="",
                            Department=department,
                            Name="超级管理员",
                            PagePower="",
                            UpdateDate=DateTime.Now
                        },
                        UpdateTime=DateTime.Today
                    };
                    _suserRepository.Add(suser);
                }
                _unitOfWork.Commit();
            }
        }

        public void UnInstall()
        {
            throw new NotImplementedException();
        }
    }
}
