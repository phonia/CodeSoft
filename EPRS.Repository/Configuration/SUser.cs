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
			Property(e =>e.LoginName).HasColumnName("LoginName").HasMaxLength(50).HasColumnType("nvarchar").IsRequired();
			Property(e =>e.LoginPass).HasColumnName("LoginPass").HasMaxLength(50).HasColumnType("nvarchar").IsRequired();
			Property(e =>e.LoginTime).HasColumnName("LoginTime").HasColumnType("DateTime").IsRequired();
			Property(e =>e.LoginIp).HasColumnName("LoginIp").HasMaxLength(50).HasColumnType("nvarchar").IsRequired();
			Property(e =>e.LoginCount).HasColumnName("LoginCount").HasColumnType("int").IsRequired();
			Property(e =>e.CreateTime).HasColumnName("CreateTime").HasColumnType("DateTime").IsRequired();
			Property(e =>e.UpdateTime).HasColumnName("UpdateTime").HasColumnType("DateTime").IsRequired();
			Property(e =>e.IsMultiUser).HasColumnName("IsMultiUser").HasColumnType("bit").IsRequired();
			Property(e =>e.IsWork).HasColumnName("IsWork").HasColumnType("bit").IsRequired();
			Property(e =>e.IsEnable).HasColumnName("IsEnable").HasColumnType("bit").IsRequired();
            HasOptional(e=>e.Department).WithMany(e=>e.SUsers);
            HasOptional(e=>e.Position).WithMany(e=>e.SUsers);
		}
	}
}
