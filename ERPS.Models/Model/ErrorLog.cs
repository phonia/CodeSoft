#region
/***********************************************
 * 
 * 
 * ********************************************/
#endregion

using Infrastructure;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace ERPS.Models
{
    /// <summary>
    /// ErrorLog表实体类
    /// </summary>
	[Serializable]
    public partial class ErrorLog:EntityBase,IAggregateRoot
    {
		/// <summary>
		/// 主键Id
		/// </summary>
		public int Id {get;set;}
		 
		/// <summary>
		/// 出错时间
		/// </summary>
		public DateTime ErrTime {get;set;}
		 
		/// <summary>
		/// 浏览器版本
		/// </summary>
		public String BrowserVersion {get;set;}
		 
		/// <summary>
		/// 浏览器
		/// </summary>
		public String BrowserType {get;set;}
		 
		/// <summary>
		/// IP
		/// </summary>
		public String Ip {get;set;}
		 
		/// <summary>
		/// 异常页面
		/// </summary>
		public String PageUrl {get;set;}
		 
		/// <summary>
		/// 异常消息
		/// </summary>
		public String ErrMessage {get;set;}
		 
		/// <summary>
		/// 异常源
		/// </summary>
		public String ErrSource {get;set;}
		 
		/// <summary>
		/// 堆栈轨迹
		/// </summary>
		public String StackTrace {get;set;}
		 
		/// <summary>
		/// 帮助连接
		/// </summary>
		public String HelpLink {get;set;}
		 
		/// <summary>
		/// 错误类型，0=后台，1=前台，......
		/// </summary>
		public bool Type {get;set;}
		 

		protected override void Validate()
        {
            throw new NotImplementedException();
        }
	}
}
