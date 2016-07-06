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
    /// Department 实体类
    /// </summary>
    [Serializable]
    public partial class Department:EntityBase,IAggregateRoot
    {
        /// <summary>
        /// 主键Id
        /// </summary>
        public int Id {get;set;}
        /// <summary>
        /// 部门ID，内容为001001001，即每低一级部门，编码增加三位小数
        /// </summary>
        public String Code {get;set;}
        /// <summary>
        /// 部门名称
        /// </summary>
        public String Name {get;set;}
        /// <summary>
        /// 备注
        /// </summary>
        public String Notes {get;set;}
        /// <summary>
        /// 排序
        /// </summary>
        public int Sort {get;set;}
        /// <summary>
        /// 深度
        /// </summary>
        public int Depth {get;set;}
        /// <summary>
        /// 修改时间
        /// </summary>
        public DateTime UpdateDate {get;set;}
        ///<summary>
        ///用户所属部门
        ///</summary>
        public virtual IList<SUser> SUsers{get;set;}
        ///<summary>
        ///
        ///</summary>
        public virtual IList<Position> Positions{get;set;}
        protected override void Validate()
        {
            throw new NotImplementedException();
        }
	}
}
