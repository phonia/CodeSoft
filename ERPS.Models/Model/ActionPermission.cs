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
    /// 操作权限
    /// ActionPermission 实体类
    /// </summary>
    [Serializable]
    public partial class ActionPermission:EntityBase,IAggregateRoot
    {
        /// <summary>
        /// 主键Id
        /// </summary>
        public int Id {get;set;}

        /// <summary>
        /// 名称
        /// </summary>
        public ActionSign ActionSign {get;set;}

        /// <summary>
        /// url
        /// </summary>
        public String Url {get;set;}

        /// <summary>
        /// 排序
        /// </summary>
        public int Sort {get;set;}

        ///<summary>
        ///操作权限
        ///</summary>
        public virtual MenuInfo MenuInfo{get;set;}

        protected override void Validate()
        {
            throw new NotImplementedException();
        }
    }
}
