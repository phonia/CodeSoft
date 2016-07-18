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
        public String NName {get;set;}

        /// <summary>
        /// 头像图片路径
        /// </summary>
        public Byte[] PhotoImg {get;set;}

        /// <summary>
        /// 性别（0=未知，1=男，2=女）
        /// </summary>
        public SexDTO Sex {get;set;}

        /// <summary>
        /// 出生日期
        /// </summary>
        public DateTime Birthday {get;set;}

        /// <summary>
        /// 籍贯
        /// </summary>
        public String NativePlace {get;set;}

        /// <summary>
        /// 民族
        /// </summary>
        public String NationalName {get;set;}

        /// <summary>
        /// 个人--学历
        /// </summary>
        public EducationDTO Education {get;set;}

        /// <summary>
        /// 毕业学校
        /// </summary>
        public String GraduateCollege {get;set;}

        /// <summary>
        /// 毕业专业
        /// </summary>
        public String GraduateSpecialty {get;set;}

        /// <summary>
        /// 个人--联系电话
        /// </summary>
        public String Tel {get;set;}

        /// <summary>
        /// 个人--移动电话
        /// </summary>
        public String Mobile {get;set;}

        /// <summary>
        /// 个人--联系邮箱
        /// </summary>
        public String Email {get;set;}

        /// <summary>
        /// 个人--QQ
        /// </summary>
        public String Qq {get;set;}

        /// <summary>
        /// 个人--Msn
        /// </summary>
        public String Msn {get;set;}

        /// <summary>
        /// 个人--通讯地址
        /// </summary>
        public String Address {get;set;}

        /// <summary>
        /// 备注
        /// </summary>
        public String Content {get;set;}

    }
}
