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
    ///OnLineInfo 实体类映射
    ///</summary>
    public class OnLineInfoConfiguration:ComplexTypeConfiguration<OnLineInfo>
    {
        public OnLineInfoConfiguration()
        {
			Property(e =>e.IsOnLine).HasColumnName("IsOnLine").HasColumnType("bit").IsRequired();
			Property(e =>e.CurrentPage).HasColumnName("CurrentPage").HasColumnType("nvarchar").IsOptional();
			Property(e =>e.CurrentPageTitle).HasColumnName("CurrentPageTitle").HasColumnType("nvarchar").IsOptional();
			Property(e =>e.SessionId).HasColumnName("SessionId").HasColumnType("nvarchar").IsOptional();
			Property(e =>e.UserAgent).HasColumnName("UserAgent").HasColumnType("nvarchar").IsOptional();
			Property(e =>e.OperatingSystem).HasColumnName("OperatingSystem").HasColumnType("nvarchar").IsOptional();
			Property(e =>e.TerminalType).HasColumnName("TerminalType").HasColumnType("nvarchar").IsOptional();
			Property(e =>e.BrowserName).HasColumnName("BrowserName").HasColumnType("nvarchar").IsOptional();
			Property(e =>e.BrowserVersion).HasColumnName("BrowserVersion").HasColumnType("nvarchar").IsOptional();

        }
    }
}
