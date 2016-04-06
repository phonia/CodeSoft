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
    
    public partial class BSAccount
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public BSAccount()
        {
            this.FIDeposits = new HashSet<FIDeposit>();
            this.FIDeposits1 = new HashSet<FIDeposit>();
            this.FIPurCosts = new HashSet<FIPurCost>();
            this.FISelCosts = new HashSet<FISelCost>();
            this.PUPays = new HashSet<PUPay>();
            this.SEGathers = new HashSet<SEGather>();
        }
    
        public string AccountCode { get; set; }
        public string AccountName { get; set; }
        public string BankAccount { get; set; }
        public string AccSubject { get; set; }
        public Nullable<decimal> AccMoney { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FIDeposit> FIDeposits { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FIDeposit> FIDeposits1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FIPurCost> FIPurCosts { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FISelCost> FISelCosts { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PUPay> PUPays { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SEGather> SEGathers { get; set; }
    }
}