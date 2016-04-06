using ERP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ERP.Repository
{
    public class DataBaseHelper
    {
        public static void InintDataBase()
        {
            using (DataContext dc = new DataContext())
            {
                List<MSFunc> msFuncList = new List<MSFunc>() { 
                    new MSFunc(){FuncId="Add",FuncName="注册"},
                    new MSFunc(){FuncId="Amend",FuncName="修改"},
                    new MSFunc(){FuncId="Check",FuncName="审核"},
                    new MSFunc(){FuncId="Remove",FuncName="删除"},
                    new MSFunc(){FuncId="Export",FuncName="导出"},
                    new MSFunc(){FuncId="Print",FuncName="打印"},
                    new MSFunc(){FuncId="Query",FuncName="查询"},
                    new MSFunc(){FuncId="Save",FuncName="保存"},
                    new MSFunc(){FuncId="UnCheck",FuncName="弃审"},
                    new MSFunc(){FuncId="Abondan",FuncName="废弃"}
                };

                List<MSModule> msModuleList = new List<MSModule>() { 
                    new MSModule(){ModuleId="MSUser",ModuleName="用户管理",ModuleUrl="/MS/UserManager"},
                    new MSModule(){ModuleId="MSRole",ModuleName="角色管理",ModuleUrl="/MS/RoleManager"}
                };

                List<MSDomain> msDomainList = new List<MSDomain>() { 
                    new MSDomain(){DomainId="MS",DomainName="系统设置", MSModule=msModuleList}
                };

                List<MSRight> msRightList = new List<MSRight>() { 
                                            new MSRight(){MSFunc=msFuncList.Where(it=>it.FuncId=="Add").Single(),MSModule=msModuleList.Where(it=>it.ModuleId=="MSUser").Single(),
                        RightId=System.Guid.NewGuid()},
                                            new MSRight(){MSFunc=msFuncList.Where(it=>it.FuncId=="Amend").Single(),MSModule=msModuleList.Where(it=>it.ModuleId=="MSUser").Single(),
                        RightId=System.Guid.NewGuid()},
                                            new MSRight(){MSFunc=msFuncList.Where(it=>it.FuncId=="Remove").Single(),MSModule=msModuleList.Where(it=>it.ModuleId=="MSUser").Single(),
                        RightId=System.Guid.NewGuid()},
                                            new MSRight(){MSFunc=msFuncList.Where(it=>it.FuncId=="Query").Single(),MSModule=msModuleList.Where(it=>it.ModuleId=="MSUser").Single(),
                        RightId=System.Guid.NewGuid()},
                                            new MSRight(){MSFunc=msFuncList.Where(it=>it.FuncId=="Add").Single(),MSModule=msModuleList.Where(it=>it.ModuleId=="MSRole").Single(),
                        RightId=System.Guid.NewGuid()},
                                            new MSRight(){MSFunc=msFuncList.Where(it=>it.FuncId=="Amend").Single(),MSModule=msModuleList.Where(it=>it.ModuleId=="MSRole").Single(),
                        RightId=System.Guid.NewGuid()},
                                            new MSRight(){MSFunc=msFuncList.Where(it=>it.FuncId=="Remove").Single(),MSModule=msModuleList.Where(it=>it.ModuleId=="MSRole").Single(),
                        RightId=System.Guid.NewGuid()},
                                            new MSRight(){MSFunc=msFuncList.Where(it=>it.FuncId=="Query").Single(),MSModule=msModuleList.Where(it=>it.ModuleId=="MSRole").Single(),
                        RightId=System.Guid.NewGuid()}
                };

                List<MSRole> msRoleList = new List<MSRole>() { 
                    new MSRole(){RoleId=System.Guid.NewGuid(),RoleName="超级管理员",MSRight=msRightList}
                };

                msRoleList.ForEach(it => dc.Set<MSRole>().Add(it));
                msFuncList.ForEach(it => dc.Set<MSFunc>().Add(it));
                msRightList.ForEach(it => dc.Set<MSRight>().Add(it));
                msDomainList.ForEach(it => dc.Set<MSDomain>().Add(it));
                dc.SaveChanges();
            }
        }
    }
}
