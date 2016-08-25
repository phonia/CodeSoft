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
    /// OnLineInfo DTO
    /// </summary>
    [Serializable]
    public partial class OnLineInfoDTO
    {
        /// <summary>
        /// 用户是否在线
        /// </summary>
		[Description("用户是否在线")]
        public bool IsOnLine {get;set;}

        /// <summary>
        /// 用户当前所在页面Url
        /// </summary>
		[Description("用户当前所在页面Url")]
        public String CurrentPage {get;set;}

        /// <summary>
        /// 用户当前所在页面名称
        /// </summary>
		[Description("用户当前所在页面名称")]
        public String CurrentPageTitle {get;set;}

        /// <summary>
        /// 用户SessionId
        /// </summary>
		[Description("用户SessionId")]
        public String SessionId {get;set;}

        /// <summary>
        /// 客户端UA
        /// </summary>
		[Description("客户端UA")]
        public String UserAgent {get;set;}

        /// <summary>
        /// 操作系统
        /// </summary>
		[Description("操作系统")]
        public String OperatingSystem {get;set;}

        /// <summary>
        /// 终端类型（0=非移动设备，1=移动设备）
        /// </summary>
		[Description("终端类型（0=非移动设备，1=移动设备）")]
        public String TerminalType {get;set;}

        /// <summary>
        /// 浏览器名称
        /// </summary>
		[Description("浏览器名称")]
        public String BrowserName {get;set;}

        /// <summary>
        /// 浏览器的版本
        /// </summary>
		[Description("浏览器的版本")]
        public String BrowserVersion {get;set;}

    }
}
