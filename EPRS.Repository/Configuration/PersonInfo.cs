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
    ///PersonInfo 实体类映射
    ///个人信息
    ///</summary>
    public class PersonInfoConfiguration:ComplexTypeConfiguration<PersonInfo>
    {
        public PersonInfoConfiguration()
        {
            Property(e =>e.NName).HasColumnName("NName").HasColumnType("nvarchar").IsRequired();
            Property(e =>e.PhotoImg).HasColumnName("PhotoImg").HasColumnType("varbinary(Max)").IsRequired();
            Property(e =>e.Sex).HasColumnName("Sex").HasColumnType("int").IsRequired();
            Property(e =>e.Birthday).HasColumnName("Birthday").HasColumnType("DateTime").IsOptional();
            Property(e =>e.NativePlace).HasColumnName("NativePlace").HasColumnType("nvarchar").IsOptional();
            Property(e =>e.NationalName).HasColumnName("NationalName").HasColumnType("nvarchar").IsOptional();
            Property(e =>e.Education).HasColumnName("Education").HasColumnType("int").IsOptional();
            Property(e =>e.GraduateCollege).HasColumnName("GraduateCollege").HasColumnType("nvarchar").IsOptional();
            Property(e =>e.GraduateSpecialty).HasColumnName("GraduateSpecialty").HasColumnType("nvarchar").IsOptional();
            Property(e =>e.Tel).HasColumnName("Tel").HasColumnType("nvarchar").IsOptional();
            Property(e =>e.Mobile).HasColumnName("Mobile").HasColumnType("nvarchar").IsOptional();
            Property(e =>e.Email).HasColumnName("Email").HasColumnType("nvarchar").IsOptional();
            Property(e =>e.Qq).HasColumnName("Qq").HasColumnType("nvarchar").IsOptional();
            Property(e =>e.Msn).HasColumnName("Msn").HasColumnType("nvarchar").IsOptional();
            Property(e =>e.Address).HasColumnName("Address").HasColumnType("nvarchar").IsOptional();
            Property(e =>e.Content).HasColumnName("Content").HasColumnType("nvarchar").IsOptional();

        }
    }
}
