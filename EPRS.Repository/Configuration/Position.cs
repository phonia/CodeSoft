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
	///Position 实体类映射
	///</summary>
	public class PositionConfiguration:EntityTypeConfiguration<Position>
    {
		public PositionConfiguration()
        {
			ToTable("Position");
			HasKey(e=>e.Id);
			Property(e =>e.Id).HasColumnName("Id").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity).HasColumnType("int").IsRequired();
			Property(e =>e.Name).HasColumnName("Name").HasMaxLength(50).HasColumnType("nvarchar").IsRequired();
			Property(e =>e.PagePower).HasColumnName("PagePower").HasColumnType("nvarchar(MAX)").IsOptional();
			Property(e =>e.ControlPower).HasColumnName("ControlPower").HasColumnType("nvarchar(MAX)").IsOptional();
			Property(e =>e.UpdateDate).HasColumnName("UpdateDate").HasColumnType("DateTime").IsRequired();
            HasRequired(e=>e.Department).WithMany(e=>e.Positions);
		}
	}
}
