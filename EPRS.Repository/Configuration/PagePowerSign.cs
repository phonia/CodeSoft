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
    ///PagePowerSign 实体类映射
    ///</summary>
    public class PagePowerSignConfiguration:EntityTypeConfiguration<PagePowerSign>
    {
        public PagePowerSignConfiguration()
        {
            ToTable("PagePowerSign");
            HasKey(e=>e.Id);
			Property(e =>e.Id).HasColumnName("Id").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity).HasColumnType("int").IsRequired();
			Property(e =>e.CName).HasColumnName("CName").HasColumnType("nvarchar").IsRequired();
			Property(e =>e.EName).HasColumnName("EName").HasColumnType("nvarchar").IsRequired();

        }
    }
}
