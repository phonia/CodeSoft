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
    
    public partial class BSEmployee
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public BSEmployee()
        {
            this.CUAfterServices = new HashSet<CUAfterService>();
            this.FIDeposits = new HashSet<FIDeposit>();
            this.FIPurCosts = new HashSet<FIPurCost>();
            this.FISelCosts = new HashSet<FISelCost>();
        }
    
        public string EmployeeCode { get; set; }
        public string EmployeeName { get; set; }
        public string DepartmentCode { get; set; }
        public Nullable<int> Age { get; set; }
        public string Sex { get; set; }
        public string EduLevel { get; set; }
        public string Job { get; set; }
        public Nullable<System.DateTime> JoinDate { get; set; }
        public string TelephoneCode { get; set; }
        public string Remark { get; set; }
    
        public virtual BSDepartment BSDepartment { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CUAfterService> CUAfterServices { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FIDeposit> FIDeposits { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FIPurCost> FIPurCosts { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FISelCost> FISelCosts { get; set; }
    }
}
