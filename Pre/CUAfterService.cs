//------------------------------------------------------------------------------
// <auto-generated>
//     此代码已从模板生成。
//
//     手动更改此文件可能导致应用程序出现意外的行为。
//     如果重新生成代码，将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace Pre
{
    using System;
    using System.Collections.Generic;
    
    public partial class CUAfterService
    {
        public int AfterId { get; set; }
        public string CustomerCode { get; set; }
        public Nullable<System.DateTime> SerDate { get; set; }
        public string EmployeeCode { get; set; }
        public string Linkman { get; set; }
        public string TelephoneCode { get; set; }
        public Nullable<int> SerDays { get; set; }
        public string SerContent { get; set; }
        public string Resolvent { get; set; }
    
        public virtual BSCustomer BSCustomer { get; set; }
        public virtual BSEmployee BSEmployee { get; set; }
    }
}