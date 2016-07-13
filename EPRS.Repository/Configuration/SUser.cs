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
    ///SUser 实体类映射
    ///</summary>
    public class SUserConfiguration:EntityTypeConfiguration<SUser>
    {
        public SUserConfiguration()
        {
            ToTable("SUser");
            HasKey(e=>e.Id);
			Property(e =>e.Id).HasColumnName("Id").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity).HasColumnType("int").IsRequired();
			Property(e =>e.LoginName).HasColumnName("LoginName").HasColumnType("nvarchar").IsRequired();
			Property(e =>e.LoginPass).HasColumnName("LoginPass").HasColumnType("nvarchar").IsRequired();
			Property(e =>e.LoginTime).HasColumnName("LoginTime").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity).HasColumnType("DateTime").IsRequired();
			Property(e =>e.LoginIp).HasColumnName("LoginIp").HasColumnType("nvarchar").IsRequired();
			Property(e =>e.LoginCount).HasColumnName("LoginCount").HasColumnType("int").IsRequired();
			Property(e =>e.CreateTime).HasColumnName("CreateTime").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity).HasColumnType("DateTime").IsRequired();
			Property(e =>e.UpdateTime).HasColumnName("UpdateTime").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity).HasColumnType("DateTime").IsRequired();
			Property(e =>e.IsMultiUser).HasColumnName("IsMultiUser").HasColumnType("bit").IsRequired();
			Property(e =>e.IsWork).HasColumnName("IsWork").HasColumnType("bit").IsRequired();
			Property(e =>e.IsEnable).HasColumnName("IsEnable").HasColumnType("bit").IsRequired();
			Property(e =>e.PersonInfo).HasColumnName("PersonInfo").IsRequired();
			Property(e =>e.OnLineInfo).HasColumnName("OnLineInfo").IsRequired();
            HasRequired(e=>e.Position).WithMany(e=>e.Users).Map(e=>e.MapKey("PositionId"));
        }
    }
}
