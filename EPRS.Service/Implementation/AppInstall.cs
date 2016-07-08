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
        IPagePowerSignRepository _PagePowerSignRepository = null;
        IMenuInfoRepository _menuInfoRepository = null;
        IWebConfigRepository _webConfigRepository = null;
        ISUserRepository _suserRepository = null;
        IPositionRepository _positoryRepository = null;
        IDepartmentRepository _departmentRepository = null;

        public AppInstall(IUnitOfWork unitOfWork,IPagePowerSignRepository pagePowerSignRepository,
            IMenuInfoRepository menuInfoRepositry,IWebConfigRepository webConfigRepository,
            ISUserRepository suserRepository,IPositionRepository positoryRepository,IDepartmentRepository departmentRepository)
        {
            _unitOfWork = unitOfWork;
            _PagePowerSignRepository = pagePowerSignRepository;
            _menuInfoRepository = menuInfoRepositry;
            _webConfigRepository = webConfigRepository;
            _suserRepository = suserRepository;
            _positoryRepository = positoryRepository;
            _departmentRepository = departmentRepository;

            _PagePowerSignRepository.UnitOfWork = unitOfWork;
            _positoryRepository.UnitOfWork = unitOfWork;
            _menuInfoRepository.UnitOfWork = unitOfWork;
            _webConfigRepository.UnitOfWork = unitOfWork;
            _suserRepository.UnitOfWork = unitOfWork;
            _positoryRepository.UnitOfWork = unitOfWork;
            _departmentRepository.UnitOfWork = unitOfWork;
        }

        public void Install()
        {
            if (_PagePowerSignRepository.GetAll().Count() <= 0)
            {
                var pagePowers = new List<PagePowerSign>() { 
                    new PagePowerSign(){CName="查看",EName="LookOver"},
                    new PagePowerSign(){CName="查询",EName="LookFor"},
                    new PagePowerSign(){CName="编辑",EName="Edit"},
                    new PagePowerSign(){CName="报表",EName="Report"},
                    new PagePowerSign(){CName="删除",EName="Remove"},
                    new PagePowerSign(){CName="审核",EName="Adulting"},
                    new PagePowerSign(){CName="反审核",EName="UnAdulting"}
                };

                foreach (var node in pagePowers)
                {
                    _PagePowerSignRepository.Add(node);
                }
            }

            if (_menuInfoRepository.GetAll().Count() <= 0)
            {
                var menus = new List<MenuInfo>() { 
                    new MenuInfo(){Depth=1,IsDisplay=true,IsMenu=true,Name="个人事务",Url="",Sort=0,MenuInfos=new List<MenuInfo>(){
                        new MenuInfo(){Depth=2,IsDisplay=true,IsMenu=true,Name="个人设置",Url="",Sort=0},
                        new MenuInfo(){Depth=2,IsDisplay=true,IsMenu=true,Name="部门通讯录",Url="",Sort=0},
                        new MenuInfo(){Depth=2,IsDisplay=true,IsMenu=true,Name="公司通讯录",Url="",Sort=0}
                    }},
                    new MenuInfo(){Depth=1,IsDisplay=true,IsMenu=true,Name="信息管理",Url="",Sort=0,MenuInfos=new List<MenuInfo>(){
                        new MenuInfo(){Depth=2,IsDisplay=true,IsMenu=true,Name="信息分类管理",Url="",Sort=0},
                        new MenuInfo(){Depth=2,IsDisplay=true,IsMenu=true,Name="信息内容管理",Url="",Sort=0},
                        new MenuInfo(){Depth=2,IsDisplay=true,IsMenu=true,Name="邮件信息管理",Url="",Sort=0}
                    }},
                    new MenuInfo(){Depth=1,IsDisplay=true,IsMenu=true,Name="员工管理",Url="",Sort=0,MenuInfos=new List<MenuInfo>(){
                        new MenuInfo(){Depth=2,IsDisplay=true,IsMenu=true,Name="在职人员",Url="",Sort=0},
                        new MenuInfo(){Depth=2,IsDisplay=true,IsMenu=true,Name="离职人员",Url="",Sort=0}
                    }},
                    new MenuInfo(){Depth=1,IsDisplay=true,IsMenu=true,Name="基本设置",Url="",Sort=0,MenuInfos=new List<MenuInfo>(){
                        new MenuInfo(){Depth=2,IsDisplay=true,IsMenu=true,Name="基本参数设置",Url="",Sort=0},
                        new MenuInfo(){Depth=2,IsDisplay=true,IsMenu=true,Name="重新生成图片",Url="",Sort=0}  
                    }},
                    new MenuInfo(){Depth=1,IsDisplay=true,IsMenu=true,Name="权限管理",Url="",Sort=0,MenuInfos=new List<MenuInfo>(){
                        new MenuInfo(){Depth=2,IsDisplay=true,IsMenu=true,Name="菜单管理",Url="",Sort=0},
                        new MenuInfo(){Depth=2,IsDisplay=true,IsMenu=true,Name="页面按键名称设置",Url="",Sort=0},
                        new MenuInfo(){Depth=2,IsDisplay=true,IsMenu=true,Name="页面权限设置",Url="",Sort=0},
                        new MenuInfo(){Depth=2,IsDisplay=true,IsMenu=true,Name="部门管理",Url="",Sort=0},
                        new MenuInfo(){Depth=2,IsDisplay=true,IsMenu=true,Name="职位管理",Url="",Sort=0}
                    }},
                    new MenuInfo(){Depth=1,IsDisplay=true,IsMenu=true,Name="安全管理",Url="",Sort=0,MenuInfos=new List<MenuInfo>(){
                        new MenuInfo(){Depth=2,IsDisplay=true,IsMenu=true,Name="操作日志",Url="",Sort=0},
                        new MenuInfo(){Depth=2,IsDisplay=true,IsMenu=true,Name="错误日志",Url="",Sort=0},
                        new MenuInfo(){Depth=2,IsDisplay=true,IsMenu=true,Name="在线用户",Url="",Sort=0}
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
                        UpdateDate = DateTime.Now
                    };

                    var suser = new SUser()
                    {
                        CreateTime = DateTime.Now,
                        IsEnable = true,
                        IsMultiUser = false,
                        IsWork = true,
                        LoginCount = 0,
                        LoginIp = "0",
                        LoginName = "Admin",
                        LoginPass = "Admin",
                        LoginTime = DateTime.Now,
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
                            Birthday=DateTime.Now,
                            Content="",
                            Education=Education.HighSchool,
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
                        UpdateTime=DateTime.Now
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
