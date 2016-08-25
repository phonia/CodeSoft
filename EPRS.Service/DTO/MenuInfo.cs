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
    /// MenuInfo DTO
    /// </summary>
    [Serializable]
    public partial class MenuInfoDTO
    {
        /// <summary>
        /// 主键Id
        /// </summary>
		[Description("主键Id")]
        public int Id {get;set;}

        /// <summary>
        /// 菜单名称或各个页面功能名称
        /// </summary>
		[Description("菜单名称或各个页面功能名称")]
        public String Name {get;set;}

        /// <summary>
        /// 各页面URL（主菜单与分类菜单没有URL）
        /// </summary>
		[Description("各页面URL（主菜单与分类菜单没有URL）")]
        public String Url {get;set;}

        /// <summary>
        /// 排序
        /// </summary>
		[Description("排序")]
        public int Sort {get;set;}

        /// <summary>
        /// 深度
        /// </summary>
		[Description("深度")]
        public int Depth {get;set;}

        /// <summary>
        /// 该菜单是否在菜单栏显示，0=不显示，1=显示
        /// </summary>
		[Description("该菜单是否在菜单栏显示，0=不显示，1=显示")]
        public bool IsDisplay {get;set;}

        /// <summary>
        /// 是否是菜单还是页面
        /// </summary>
		[Description("是否是菜单还是页面")]
        public bool IsMenu {get;set;}

    }
}
