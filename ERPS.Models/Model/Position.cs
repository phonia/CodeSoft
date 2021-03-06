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
    /// 职务
    /// Position 实体类
    /// </summary>
    [Serializable]
    public partial class Position:EntityBase,IAggregateRoot
    {
        /// <summary>
        /// 主键Id
        /// </summary>
        public int Id {get;set;}

        /// <summary>
        /// 职位名称
        /// </summary>
        public String Name {get;set;}

        /// <summary>
        /// 菜单操作权限，有操作权限的菜单ID列表：|1|2|3|4|5|
        /// </summary>
        public String PagePower {get;set;}

        /// <summary>
        /// 页面功能操作权限，各个页面有操作权限的菜单ID和页面权限标志ID列表：1|2|3|4
        /// </summary>
        public String ControlPower {get;set;}

        /// <summary>
        /// 修改时间
        /// </summary>
        public DateTime UpdateDate {get;set;}

        ///<summary>
        ///用户职务
        ///</summary>
        public virtual IList<SUser> Users{get;set;}

        ///<summary>
        ///部门职务
        ///</summary>
        public virtual Department Department{get;set;}

        protected override void Validate()
        {
            throw new NotImplementedException();
        }
    }
}
