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
                    new MSModule(){ModuleId="MSUser",ModuleName="系统操作员"}
                };

                List<MSRight> msRightList = new List<MSRight>() { 
                                            new MSRight(){MSFunc=msFuncList.Where(it=>it.FuncId=="Add").Single(),MSModule=msModuleList.Where(it=>it.ModuleId=="MSUser").Single(),
                        RightId=System.Guid.NewGuid()},
                                            new MSRight(){MSFunc=msFuncList.Where(it=>it.FuncId=="Amend").Single(),MSModule=msModuleList.Where(it=>it.ModuleId=="MSUser").Single(),
                        RightId=System.Guid.NewGuid()},
                                            new MSRight(){MSFunc=msFuncList.Where(it=>it.FuncId=="Remove").Single(),MSModule=msModuleList.Where(it=>it.ModuleId=="MSUser").Single(),
                        RightId=System.Guid.NewGuid()},
                                            new MSRight(){MSFunc=msFuncList.Where(it=>it.FuncId=="Query").Single(),MSModule=msModuleList.Where(it=>it.ModuleId=="MSUser").Single(),
                        RightId=System.Guid.NewGuid()}
                };
                msFuncList.ForEach(it => dc.Set<MSFunc>().Add(it));
                msRightList.ForEach(it => dc.Set<MSRight>().Add(it));
                dc.SaveChanges();
            }
        }
    }
}
