//------------------------------------------------------------------------------
// <auto-generated>
//     此代码已从模板生成。
//
//     手动更改此文件可能导致应用程序出现意外的行为。
//     如果重新生成代码，将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace ERP.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Employee
    {
        public int EmployeeId { get; set; }
        public string Name { get; set; }
        public Sex Sex { get; set; }
        public int Age { get; set; }
    
        public virtual Department Department { get; set; }
    }
}