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
    /// UserLog 实体类
    /// </summary>
    [Serializable]
    public partial class UserLog:EntityBase,IAggregateRoot
    {
        /// <summary>
        /// 主键Id
        /// </summary>
        public int Id {get;set;}
        /// <summary>
        /// 操作时间
        /// </summary>
        public DateTime AddDate {get;set;}
        /// <summary>
        /// 登陆IP
        /// </summary>
        public String Ip {get;set;}
        /// <summary>
        /// 操作内容
        /// </summary>
        public String Notes {get;set;}
        /// <summary>
        /// 
        /// </summary>
        public SUser SUser {get;set;}
        /// <summary>
        /// 
        /// </summary>
        public MenuInfo MenuInfo {get;set;}
        protected override void Validate()
        {
            throw new NotImplementedException();
        }
	}
}
