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
	///OnLineInfo 实体类映射
	///</summary>
	public class OnLineInfoConfiguration:ComplexTypeConfiguration<OnLineInfo>
    {
		public OnLineInfoConfiguration()
        {
			Property(e =>e.IsOnLine).HasColumnType("bit").IsRequired();
			Property(e =>e.CurrentPage).HasMaxLength(50).HasColumnType("nvarchar").IsOptional();
			Property(e =>e.CurrentPageTitle).HasMaxLength(50).HasColumnType("nvarchar").IsOptional();
			Property(e =>e.SessionId).HasMaxLength(50).HasColumnType("nvarchar").IsOptional();
			Property(e =>e.UserAgent).HasMaxLength(50).HasColumnType("nvarchar").IsOptional();
			Property(e =>e.OperatingSystem).HasMaxLength(50).HasColumnType("nvarchar").IsOptional();
			Property(e =>e.TerminalType).HasMaxLength(50).HasColumnType("nvarchar").IsOptional();
			Property(e =>e.BrowserName).HasMaxLength(50).HasColumnType("nvarchar").IsOptional();
			Property(e =>e.BrowserVersion).HasMaxLength(50).HasColumnType("nvarchar").IsOptional();
		}
	}
}
