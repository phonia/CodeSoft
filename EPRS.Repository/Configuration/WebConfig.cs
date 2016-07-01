using ERPS.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
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
			Property(e =>e.Id).HasColumnName("Id").IsRequired().HasColumnType("int");
			Property(e =>e.WebName).HasColumnName("WebName").IsRequired().HasColumnType("nvarchar").HasMaxLength(50);
			Property(e =>e.WebDomain).HasColumnName("WebDomain").IsRequired().HasColumnType("nvarchar").HasMaxLength(50);
			Property(e =>e.WebEmail).HasColumnName("WebEmail").IsRequired().HasColumnType("nvarchar").HasMaxLength(50);
			Property(e =>e.LoginLogReserveTime).HasColumnName("LoginLogReserveTime").HasColumnType("int");
			Property(e =>e.UseLogReserveTime).HasColumnName("UseLogReserveTime").HasColumnType("int");
			Property(e =>e.EmailSmtp).HasColumnName("EmailSmtp").IsRequired().HasColumnType("nvarchar").HasMaxLength(50);
			Property(e =>e.EmailUserName).HasColumnName("EmailUserName").IsRequired().HasColumnType("nvarchar").HasMaxLength(50);
			Property(e =>e.EmailPassWord).HasColumnName("EmailPassWord").IsRequired().HasColumnType("nvarchar").HasMaxLength(50);
			Property(e =>e.EmailDomain).HasColumnName("EmailDomain").IsRequired().HasColumnType("nvarchar").HasMaxLength(50);
		}
	}
}
