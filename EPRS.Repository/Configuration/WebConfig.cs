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
    ///WebConfig 实体类映射
    ///系统基本参数
    ///</summary>
    public class WebConfigConfiguration:EntityTypeConfiguration<WebConfig>
    {
        public WebConfigConfiguration()
        {
            ToTable("WebConfig");
            HasKey(e=>e.Id);
            Property(e =>e.Id).HasColumnName("Id").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity).HasColumnType("int").IsRequired();
            Property(e =>e.WebName).HasColumnName("WebName").HasColumnType("nvarchar").IsRequired();
            Property(e =>e.WebDomain).HasColumnName("WebDomain").HasColumnType("nvarchar").IsRequired();
            Property(e =>e.WebEmail).HasColumnName("WebEmail").HasColumnType("nvarchar").IsRequired();
            Property(e =>e.LoginLogReserveTime).HasColumnName("LoginLogReserveTime").HasColumnType("int").IsRequired();
            Property(e =>e.UseLogReserveTime).HasColumnName("UseLogReserveTime").HasColumnType("int").IsRequired();
            Property(e =>e.EmailSmtp).HasColumnName("EmailSmtp").HasColumnType("nvarchar").IsRequired();
            Property(e =>e.EmailUserName).HasColumnName("EmailUserName").HasColumnType("nvarchar").IsRequired();
            Property(e =>e.EmailPassWord).HasColumnName("EmailPassWord").HasColumnType("nvarchar").IsRequired();
            Property(e =>e.EmailDomain).HasColumnName("EmailDomain").HasColumnType("nvarchar").IsRequired();

        }
    }
}
