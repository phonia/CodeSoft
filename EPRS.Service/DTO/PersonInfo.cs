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
    /// PersonInfo DTO
    /// </summary>
    [Serializable]
    public partial class PersonInfoDTO
    {
        /// <summary>
        /// 用户中文名称
        /// </summary>
		[Description("用户中文名称")]
        public String NName {get;set;}

        /// <summary>
        /// 头像图片路径
        /// </summary>
		[Description("头像图片路径")]
        public Byte[] PhotoImg {get;set;}

        /// <summary>
        /// 性别（0=未知，1=男，2=女）
        /// </summary>
		[Description("性别（0=未知，1=男，2=女）")]
        public SexDTO Sex {get;set;}

        /// <summary>
        /// 出生日期
        /// </summary>
		[Description("出生日期")]
        public DateTime Birthday {get;set;}

        /// <summary>
        /// 籍贯
        /// </summary>
		[Description("籍贯")]
        public String NativePlace {get;set;}

        /// <summary>
        /// 民族
        /// </summary>
		[Description("民族")]
        public String NationalName {get;set;}

        /// <summary>
        /// 个人--学历
        /// </summary>
		[Description("个人--学历")]
        public EducationDTO Education {get;set;}

        /// <summary>
        /// 毕业学校
        /// </summary>
		[Description("毕业学校")]
        public String GraduateCollege {get;set;}

        /// <summary>
        /// 毕业专业
        /// </summary>
		[Description("毕业专业")]
        public String GraduateSpecialty {get;set;}

        /// <summary>
        /// 个人--联系电话
        /// </summary>
		[Description("个人--联系电话")]
        public String Tel {get;set;}

        /// <summary>
        /// 个人--移动电话
        /// </summary>
		[Description("个人--移动电话")]
        public String Mobile {get;set;}

        /// <summary>
        /// 个人--联系邮箱
        /// </summary>
		[Description("个人--联系邮箱")]
        public String Email {get;set;}

        /// <summary>
        /// 个人--QQ
        /// </summary>
		[Description("个人--QQ")]
        public String Qq {get;set;}

        /// <summary>
        /// 个人--Msn
        /// </summary>
		[Description("个人--Msn")]
        public String Msn {get;set;}

        /// <summary>
        /// 个人--通讯地址
        /// </summary>
		[Description("个人--通讯地址")]
        public String Address {get;set;}

        /// <summary>
        /// 备注
        /// </summary>
		[Description("备注")]
        public String Content {get;set;}

    }
}
