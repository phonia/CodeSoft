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
    
    public partial class PRPlan
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PRPlan()
        {
            this.PRProduces = new HashSet<PRProduce>();
        }
    
        public string PRPlanCode { get; set; }
        public Nullable<System.DateTime> PRPlanDate { get; set; }
        public string OperatorCode { get; set; }
        public string SEOrderCode { get; set; }
        public string InvenCode { get; set; }
        public Nullable<int> Quantity { get; set; }
        public Nullable<System.DateTime> FinishDate { get; set; }
        public string IsFlag { get; set; }
    
        public virtual BSInven BSInven { get; set; }
        public virtual SYOperator SYOperator { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PRProduce> PRProduces { get; set; }
    }
}
