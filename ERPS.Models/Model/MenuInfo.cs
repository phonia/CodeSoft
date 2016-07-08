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
    /// MenuInfo 实体类
    /// </summary>
    [Serializable]
    public partial class MenuInfo:EntityBase,IAggregateRoot
    {
        /// <summary>
        /// 主键Id
        /// </summary>
        public int Id {get;set;}
        /// <summary>
        /// 菜单名称或各个页面功能名称
        /// </summary>
        public String Name {get;set;}
        /// <summary>
        /// 各页面URL（主菜单与分类菜单没有URL）
        /// </summary>
        public String Url {get;set;}
        /// <summary>
        /// 排序
        /// </summary>
        public int Sort {get;set;}
        /// <summary>
        /// 深度
        /// </summary>
        public int Depth {get;set;}
        /// <summary>
        /// 该菜单是否在菜单栏显示，0=不显示，1=显示
        /// </summary>
        public bool IsDisplay {get;set;}
        /// <summary>
        /// 是否是菜单还是页面
        /// </summary>
        public bool IsMenu {get;set;}
        /// <summary>
        /// 
        /// </summary>
        public MenuInfo Parent {get;set;}
        ///<summary>
        ///
        ///</summary>
        public virtual IList<MenuInfo> MenuInfos{get;set;}
        ///<summary>
        ///
        ///</summary>
        public virtual IList<UserLog> UserLogs{get;set;}

        protected override void Validate()
        {
            throw new NotImplementedException();
        }
	}
}
