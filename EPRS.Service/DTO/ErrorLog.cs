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
    /// ErrorLog DTO
    /// </summary>
    [Serializable]
    public partial class ErrorLogDTO
    {
        /// <summary>
        /// 主键Id
        /// </summary>
		[Description("主键Id")]
        public int Id {get;set;}

        /// <summary>
        /// 出错时间
        /// </summary>
		[Description("出错时间")]
        public DateTime ErrTime {get;set;}

        /// <summary>
        /// 浏览器版本
        /// </summary>
		[Description("浏览器版本")]
        public String BrowserVersion {get;set;}

        /// <summary>
        /// 浏览器
        /// </summary>
		[Description("浏览器")]
        public String BrowserType {get;set;}

        /// <summary>
        /// IP
        /// </summary>
		[Description("IP")]
        public String Ip {get;set;}

        /// <summary>
        /// 异常页面
        /// </summary>
		[Description("异常页面")]
        public String PageUrl {get;set;}

        /// <summary>
        /// 异常消息
        /// </summary>
		[Description("异常消息")]
        public String ErrMessage {get;set;}

        /// <summary>
        /// 异常源
        /// </summary>
		[Description("异常源")]
        public String ErrSource {get;set;}

        /// <summary>
        /// 堆栈轨迹
        /// </summary>
		[Description("堆栈轨迹")]
        public String StackTrace {get;set;}

        /// <summary>
        /// 帮助连接
        /// </summary>
		[Description("帮助连接")]
        public String HelpLink {get;set;}

        /// <summary>
        /// 错误类型，0=后台，1=前台，......
        /// </summary>
		[Description("错误类型，0=后台，1=前台，......")]
        public bool Type {get;set;}

    }
}
