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
	///</summary>
	public class PersonInfoConfiguration:ComplexTypeConfiguration<PersonInfo>
    {
		public PersonInfoConfiguration()
        {
			Property(e =>e.NName).HasMaxLength(50).HasColumnType("nvarchar").IsRequired();
			Property(e =>e.PhotoImg).HasColumnType("varbinary(Max)").IsRequired();
			Property(e =>e.Sex).HasColumnType("int").IsRequired();
			Property(e =>e.Birthday).HasColumnType("DateTime").IsOptional();
			Property(e =>e.NativePlace).HasMaxLength(50).HasColumnType("nvarchar").IsOptional();
			Property(e =>e.NationalName).HasMaxLength(50).HasColumnType("nvarchar").IsOptional();
			Property(e =>e.Education).HasColumnType("int").IsOptional();
			Property(e =>e.GraduateCollege).HasMaxLength(50).HasColumnType("nvarchar").IsOptional();
			Property(e =>e.GraduateSpecialty).HasMaxLength(50).HasColumnType("nvarchar").IsOptional();
			Property(e =>e.Tel).HasMaxLength(50).HasColumnType("nvarchar").IsOptional();
			Property(e =>e.Mobile).HasMaxLength(50).HasColumnType("nvarchar").IsOptional();
			Property(e =>e.Email).HasMaxLength(50).HasColumnType("nvarchar").IsOptional();
			Property(e =>e.Qq).HasMaxLength(50).HasColumnType("nvarchar").IsOptional();
			Property(e =>e.Msn).HasMaxLength(50).HasColumnType("nvarchar").IsOptional();
			Property(e =>e.Address).HasMaxLength(50).HasColumnType("nvarchar").IsOptional();
			Property(e =>e.Content).HasMaxLength(50).HasColumnType("nvarchar").IsOptional();
		}
	}
}
