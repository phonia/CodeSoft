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
    
    public partial class STGetMaterial
    {
        public string STGetCode { get; set; }
        public Nullable<System.DateTime> STGetDate { get; set; }
        public string OperatorCode { get; set; }
        public string PRProduceCode { get; set; }
        public string StoreCode { get; set; }
        public string InvenCode { get; set; }
        public Nullable<decimal> UnitPrice { get; set; }
        public Nullable<int> Quantity { get; set; }
        public string BillType { get; set; }
        public string EmployeeCode { get; set; }
        public string IsFlag { get; set; }
    
        public virtual BSInven BSInven { get; set; }
        public virtual BSStore BSStore { get; set; }
        public virtual PRProduce PRProduce { get; set; }
        public virtual SYOperator SYOperator { get; set; }
    }
}
