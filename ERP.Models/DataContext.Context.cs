﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class DataContext : DbContext
    {
        public DataContext()
            : base("name=DataContext")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<MSUser> MSUserSet { get; set; }
        public virtual DbSet<MSModule> MSModuleSet { get; set; }
        public virtual DbSet<MSFunc> MSFuncSet { get; set; }
        public virtual DbSet<MSRight> MSRightSet { get; set; }
        public virtual DbSet<MSRole> MSRoleSet { get; set; }
        public virtual DbSet<Department> DepartmentSet { get; set; }
        public virtual DbSet<Employee> EmployeeSet { get; set; }
        public virtual DbSet<MSDomain> MSDomainSet { get; set; }
    }
}
