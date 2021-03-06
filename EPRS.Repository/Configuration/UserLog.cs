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
    ///UserLog 实体类映射
    ///用户日志
    ///</summary>
    public class UserLogConfiguration:EntityTypeConfiguration<UserLog>
    {
        public UserLogConfiguration()
        {
            ToTable("UserLog");
            HasKey(e=>e.Id);
            Property(e =>e.Id).HasColumnName("Id").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity).HasColumnType("int").IsRequired();
            Property(e =>e.AddDate).HasColumnName("AddDate").HasColumnType("DateTime").IsRequired();
            Property(e =>e.Ip).HasColumnName("Ip").HasColumnType("nvarchar").IsOptional();
            Property(e =>e.Notes).HasColumnName("Notes").HasColumnType("nvarchar").IsOptional();
            HasRequired(e=>e.User).WithMany(e=>e.UserLogs).Map(e=>e.MapKey("UserId"));
            HasOptional(e=>e.MenuInfo).WithMany(e=>e.UserLogs).Map(e=>e.MapKey("MenuInfoId"));

        }
    }
}
