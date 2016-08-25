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
    /// Department DTO
    /// </summary>
    [Serializable]
    public partial class DepartmentDTO
    {
        /// <summary>
        /// 主键Id
        /// </summary>
		[Description("主键Id")]
        public int Id {get;set;}

        /// <summary>
        /// 部门ID，内容为001001001，即每低一级部门，编码增加三位小数
        /// </summary>
		[Description("部门ID，内容为001001001，即每低一级部门，编码增加三位小数")]
        public String Code {get;set;}

        /// <summary>
        /// 部门名称
        /// </summary>
		[Description("部门名称")]
        public String Name {get;set;}

        /// <summary>
        /// 备注
        /// </summary>
		[Description("备注")]
        public String Notes {get;set;}

        /// <summary>
        /// 排序
        /// </summary>
		[Description("排序")]
        public int Sort {get;set;}

        /// <summary>
        /// 深度
        /// </summary>
		[Description("深度")]
        public int Depth {get;set;}

        /// <summary>
        /// 修改时间
        /// </summary>
		[Description("修改时间")]
        public DateTime UpdateDate {get;set;}

    }
}
