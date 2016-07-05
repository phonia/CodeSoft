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
	///Department 实体类映射
	///</summary>
	public class DepartmentConfiguration:EntityTypeConfiguration<Department>
    {
		public DepartmentConfiguration()
        {
			ToTable("Department");
			HasKey(e=>e.Id);
			Property(e =>e.Id).HasColumnName("Id").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity).HasColumnType("int").IsRequired();
			Property(e =>e.Code).HasColumnName("Code").HasMaxLength(50).HasColumnType("nvarchar").IsRequired();
			Property(e =>e.Name).HasColumnName("Name").HasMaxLength(50).HasColumnType("nvarchar").IsRequired();
			Property(e =>e.Notes).HasColumnName("Notes").HasMaxLength(250).HasColumnType("nvarchar").IsOptional();
			Property(e =>e.Sort).HasColumnName("Sort").HasColumnType("int").IsRequired();
			Property(e =>e.Depth).HasColumnName("Depth").HasColumnType("int").IsRequired();
			Property(e =>e.UpdateDate).HasColumnName("UpdateDate").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Computed).HasColumnType("DateTime").IsRequired();
		}
	}
}
