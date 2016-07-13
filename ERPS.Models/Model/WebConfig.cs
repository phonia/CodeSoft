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
    /// WebConfig 实体类
    /// </summary>
    [Serializable]
    public partial class WebConfig:EntityBase,IAggregateRoot
    {
        /// <summary>
        /// 主键Id
        /// </summary>
        public int Id {get;set;}

        /// <summary>
        /// 基本信息--网站名称
        /// </summary>
        public String WebName {get;set;}

        /// <summary>
        /// 基本信息--网站地址
        /// </summary>
        public String WebDomain {get;set;}

        /// <summary>
        /// 基本信息--管理员邮箱
        /// </summary>
        public String WebEmail {get;set;}

        /// <summary>
        /// 日志--系统登陆日志保留时间，0=无限制，N（数字）= X月
        /// </summary>
        public int LoginLogReserveTime {get;set;}

        /// <summary>
        /// 日志--系统操作日志保留时间，0=无限制，N（数字）= X月
        /// </summary>
        public int UseLogReserveTime {get;set;}

        /// <summary>
        /// 邮件设置--SMTP服务器
        /// </summary>
        public String EmailSmtp {get;set;}

        /// <summary>
        /// 邮件设置--登录用户名
        /// </summary>
        public String EmailUserName {get;set;}

        /// <summary>
        /// 邮件设置--登录密码
        /// </summary>
        public String EmailPassWord {get;set;}

        /// <summary>
        /// 邮件设置--邮件域名
        /// </summary>
        public String EmailDomain {get;set;}

        protected override void Validate()
        {
            throw new NotImplementedException();
        }
    }
}
