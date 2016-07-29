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

    }
}
