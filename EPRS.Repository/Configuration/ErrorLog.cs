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
    ///ErrorLog 实体类映射
    ///</summary>
    public class ErrorLogConfiguration:EntityTypeConfiguration<ErrorLog>
    {
        public ErrorLogConfiguration()
        {
            ToTable("ErrorLog");
            HasKey(e=>e.Id);
			Property(e =>e.Id).HasColumnName("Id").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity).HasColumnType("int").IsRequired();
			Property(e =>e.ErrTime).HasColumnName("ErrTime").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity).HasColumnType("DateTime").IsRequired();
			Property(e =>e.BrowserVersion).HasColumnName("BrowserVersion").HasColumnType("nvarchar").IsOptional();
			Property(e =>e.BrowserType).HasColumnName("BrowserType").HasColumnType("nvarchar").IsOptional();
			Property(e =>e.Ip).HasColumnName("Ip").HasColumnType("nvarchar").IsOptional();
			Property(e =>e.PageUrl).HasColumnName("PageUrl").HasColumnType("nvarchar").IsOptional();
			Property(e =>e.ErrMessage).HasColumnName("ErrMessage").HasColumnType("nvarchar").IsOptional();
			Property(e =>e.ErrSource).HasColumnName("ErrSource").HasColumnType("nvarchar").IsOptional();
			Property(e =>e.StackTrace).HasColumnName("StackTrace").HasColumnType("nvarchar").IsOptional();
			Property(e =>e.HelpLink).HasColumnName("HelpLink").HasColumnType("nvarchar").IsOptional();
			Property(e =>e.Type).HasColumnName("Type").HasColumnType("bit").IsRequired();

        }
    }
}
