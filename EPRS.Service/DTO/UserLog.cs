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
    /// UserLog DTO
    /// </summary>
    [Serializable]
    public partial class UserLogDTO
    {
        /// <summary>
        /// 主键Id
        /// </summary>
		[Description("主键Id")]
        public int Id {get;set;}

        /// <summary>
        /// 操作时间
        /// </summary>
		[Description("操作时间")]
        public DateTime AddDate {get;set;}

        /// <summary>
        /// 登陆IP
        /// </summary>
		[Description("登陆IP")]
        public String Ip {get;set;}

        /// <summary>
        /// 操作内容
        /// </summary>
		[Description("操作内容")]
        public String Notes {get;set;}

    }
}
