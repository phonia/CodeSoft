/***********************************************
* auto-generated code from T4
* 
* ********************************************/

using ERPS.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace EPRS.Repository
{
    ///<summary>
    ///ActionPermission 实体类映射
    ///操作权限
    ///</summary>
    public class ActionPermissionConfiguration:EntityTypeConfiguration<ActionPermission>
    {
        public ActionPermissionConfiguration()
        {
            ToTable("ActionPermission");
            HasKey(e=>e.Id);
            Property(e =>e.Id).HasColumnName("Id").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity).HasColumnType("int").IsRequired();
            Property(e =>e.ActionSign).HasColumnName("ActionSign").HasColumnType("int").IsRequired();
            Property(e =>e.Url).HasColumnName("Url").HasColumnType("nvarchar").IsRequired();
            Property(e =>e.Sort).HasColumnName("Sort").HasColumnType("int").IsRequired();
            HasRequired(e=>e.MenuInfo).WithMany(e=>e.ActionPermissions).Map(e=>e.MapKey("MenuInfoId"));
        }
    }
}
