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
    /// SUser DTO
    /// </summary>
    [Serializable]
    public partial class SUserDTO
    {
        /// <summary>
        /// 主键Id
        /// </summary>
		[Description("主键Id")]
        public int Id {get;set;}

        /// <summary>
        /// 登陆账号
        /// </summary>
		[Description("登陆账号")]
        public String LoginName {get;set;}

        /// <summary>
        /// 登陆密码
        /// </summary>
		[Description("登陆密码")]
        public String LoginPass {get;set;}

        /// <summary>
        /// 最后登陆时间
        /// </summary>
		[Description("最后登陆时间")]
        public DateTime LoginTime {get;set;}

        /// <summary>
        /// 最后登陆IP
        /// </summary>
		[Description("最后登陆IP")]
        public String LoginIp {get;set;}

        /// <summary>
        /// 登陆次数
        /// </summary>
		[Description("登陆次数")]
        public int LoginCount {get;set;}

        /// <summary>
        /// 注册时间
        /// </summary>
		[Description("注册时间")]
        public DateTime CreateTime {get;set;}

        /// <summary>
        /// 资料最后修改日期
        /// </summary>
		[Description("资料最后修改日期")]
        public DateTime UpdateTime {get;set;}

        /// <summary>
        /// 是否允许同一帐号多人使用，0=只能单个在线，1=可以多人同时在线
        /// </summary>
		[Description("是否允许同一帐号多人使用，0=只能单个在线，1=可以多人同时在线")]
        public bool IsMultiUser {get;set;}

        /// <summary>
        /// 0=离职，1=就职
        /// </summary>
		[Description("0=离职，1=就职")]
        public bool IsWork {get;set;}

        /// <summary>
        /// 账号是否启用，1=true(启用)，0=false（禁用）
        /// </summary>
		[Description("账号是否启用，1=true(启用)，0=false（禁用）")]
        public bool IsEnable {get;set;}

        /// <summary>
        /// 个人信息
        /// </summary>
		[Description("个人信息")]
        public PersonInfoDTO PersonInfo {get;set;}

        /// <summary>
        /// 在线信息
        /// </summary>
		[Description("在线信息")]
        public OnLineInfoDTO OnLineInfo {get;set;}

    }
}
