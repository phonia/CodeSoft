/***********************************************
* auto-generated code from T4
* 
* ********************************************/

using Infrastructure;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace ERPS.Models
{
    /// <summary>
    /// PagePowerSign 实体类
    /// </summary>
    [Serializable]
    public partial class PagePowerSign:EntityBase,IAggregateRoot
    {
        /// <summary>
        /// 
        /// </summary>
        public int Id {get;set;}

        /// <summary>
        /// 权限名称，如：浏览、添加、修改、删除、报表、查询、调动/分配、设置等(名称可以自由定，但建议取有意义的名称)
        /// </summary>
        public String CName {get;set;}

        /// <summary>
        /// 权限英文名称，除了在英文版权限设置时显示对应菜单外，还用来在页面程序中区分页面不同位置所调用的权限(在检测页面权限时使用)
        /// </summary>
        public String EName {get;set;}

        protected override void Validate()
        {
            throw new NotImplementedException();
        }
    }
}
