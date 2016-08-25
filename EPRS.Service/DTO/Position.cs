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

namespace EPRS.Service
{
    /// <summary>
    /// Position DTO
    /// </summary>
    [Serializable]
    public partial class PositionDTO
    {
        /// <summary>
        /// 主键Id
        /// </summary>
		[Description("主键Id")]
        public int Id {get;set;}

        /// <summary>
        /// 职位名称
        /// </summary>
		[Description("职位名称")]
        public String Name {get;set;}

        /// <summary>
        /// 菜单操作权限，有操作权限的菜单ID列表：|1|2|3|4|5|
        /// </summary>
		[Description("菜单操作权限，有操作权限的菜单ID列表：|1|2|3|4|5|")]
        public String PagePower {get;set;}

        /// <summary>
        /// 页面功能操作权限，各个页面有操作权限的菜单ID和页面权限标志ID列表：1|2|3|4
        /// </summary>
		[Description("页面功能操作权限，各个页面有操作权限的菜单ID和页面权限标志ID列表：1|2|3|4")]
        public String ControlPower {get;set;}

        /// <summary>
        /// 修改时间
        /// </summary>
		[Description("修改时间")]
        public DateTime UpdateDate {get;set;}

    }
}
