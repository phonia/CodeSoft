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
	///MenuInfo 实体类映射
	///</summary>
	public class MenuInfoConfiguration:EntityTypeConfiguration<MenuInfo>
    {
		public MenuInfoConfiguration()
        {
			ToTable("MenuInfo");
			HasKey(e=>e.Id);
			Property(e =>e.Id).HasColumnName("Id").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity).HasColumnType("int").IsRequired();
			Property(e =>e.Name).HasColumnName("Name").HasMaxLength(50).HasColumnType("nvarchar").IsRequired();
			Property(e =>e.Url).HasColumnName("Url").HasMaxLength(250).HasColumnType("nvarchar").IsRequired();
			Property(e =>e.Sort).HasColumnName("Sort").HasColumnType("int").IsRequired();
			Property(e =>e.Depth).HasColumnName("Depth").HasColumnType("int").IsRequired();
			Property(e =>e.IsDisplay).HasColumnName("IsDisplay").HasColumnType("bit").IsRequired();
			Property(e =>e.IsMenu).HasColumnName("IsMenu").HasColumnType("bit").IsRequired();
			HasOptional(e => e.Parent).WithMany(e => e.MenuInfos).HasForeignKey(e => e.Id);
		}
	}
}
