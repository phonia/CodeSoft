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
        public int Id {get;set;}

        /// <summary>
        /// 登陆账号
        /// </summary>
        public String LoginName {get;set;}

        /// <summary>
        /// 登陆密码
        /// </summary>
        public String LoginPass {get;set;}

        /// <summary>
        /// 最后登陆时间
        /// </summary>
        public DateTime LoginTime {get;set;}

        /// <summary>
        /// 最后登陆IP
        /// </summary>
        public String LoginIp {get;set;}

        /// <summary>
        /// 登陆次数
        /// </summary>
        public int LoginCount {get;set;}

        /// <summary>
        /// 注册时间
        /// </summary>
        public DateTime CreateTime {get;set;}

        /// <summary>
        /// 资料最后修改日期
        /// </summary>
        public DateTime UpdateTime {get;set;}

        /// <summary>
        /// 是否允许同一帐号多人使用，0=只能单个在线，1=可以多人同时在线
        /// </summary>
        public bool IsMultiUser {get;set;}

        /// <summary>
        /// 0=离职，1=就职
        /// </summary>
        public bool IsWork {get;set;}

        /// <summary>
        /// 账号是否启用，1=true(启用)，0=false（禁用）
        /// </summary>
        public bool IsEnable {get;set;}

        /// <summary>
        /// 个人信息
        /// </summary>
        public PersonInfoDTO PersonInfo {get;set;}

        /// <summary>
        /// 在线信息
        /// </summary>
        public OnLineInfoDTO OnLineInfo {get;set;}

    }
}
