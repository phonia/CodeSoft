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
	///WebConfig 实体类映射
	///</summary>
	public class WebConfigConfiguration:EntityTypeConfiguration<WebConfig>
    {
		public WebConfigConfiguration()
        {
			ToTable("WebConfig");
			HasKey(e=>e.Id);
			Property(e =>e.Id).HasColumnName("Id").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity).HasColumnType("int").IsRequired();
			Property(e =>e.WebName).HasColumnName("WebName").HasMaxLength(50).HasColumnType("nvarchar").IsRequired();
			Property(e =>e.WebDomain).HasColumnName("WebDomain").HasMaxLength(50).HasColumnType("nvarchar").IsRequired();
			Property(e =>e.WebEmail).HasColumnName("WebEmail").HasMaxLength(50).HasColumnType("nvarchar").IsRequired();
			Property(e =>e.LoginLogReserveTime).HasColumnName("LoginLogReserveTime").HasColumnType("int").IsOptional();
			Property(e =>e.UseLogReserveTime).HasColumnName("UseLogReserveTime").HasColumnType("int").IsOptional();
			Property(e =>e.EmailSmtp).HasColumnName("EmailSmtp").HasMaxLength(50).HasColumnType("nvarchar").IsRequired();
			Property(e =>e.EmailUserName).HasColumnName("EmailUserName").HasMaxLength(50).HasColumnType("nvarchar").IsRequired();
			Property(e =>e.EmailPassWord).HasColumnName("EmailPassWord").HasMaxLength(50).HasColumnType("nvarchar").IsRequired();
			Property(e =>e.EmailDomain).HasColumnName("EmailDomain").HasMaxLength(50).HasColumnType("nvarchar").IsRequired();
		}
	}
}
