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
    /// ActionPermission DTO
    /// </summary>
    [Serializable]
    public partial class ActionPermissionDTO
    {
        /// <summary>
        /// 主键Id
        /// </summary>
		[Description("主键Id")]
        public int Id {get;set;}

        /// <summary>
        /// 名称
        /// </summary>
		[Description("名称")]
        public ActionSignDTO ActionSign {get;set;}

        /// <summary>
        /// url
        /// </summary>
		[Description("url")]
        public String Url {get;set;}

        /// <summary>
        /// 排序
        /// </summary>
		[Description("排序")]
        public int Sort {get;set;}

    }
}
