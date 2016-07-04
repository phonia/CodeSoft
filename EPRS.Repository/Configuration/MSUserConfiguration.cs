using ERPS.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;

namespace EPRS.Repository
{
    public class MSUserConfiguration:EntityTypeConfiguration<MSUser>
    {
        public MSUserConfiguration()
        {
            ToTable("MSUser");
            HasKey(e => e.Name).Property(e => e.Name).IsRequired().HasColumnName("Name").HasMaxLength(50);
            Property(e => e.ContactNumber).IsRequired().HasColumnName("ContactNumber").HasMaxLength(50);
            Property(e => e.Email).HasMaxLength(50);
            Property(e => e.MSRole).IsRequired().HasColumnType("int");
            Property(e => e.Pwd).IsRequired().HasMaxLength(50);
            Property(e => e.Sex).IsRequired().HasColumnType("int");
            Property(e => e.MSImage).HasColumnType("varbinary(MAX)");
        }
    }

    public class Person
    {
        public String Name { get; set; }
        public Address Address { get; set; }
        public IList<Tel> Tel { get; set; }
    }

    public class Tel
    {
        public String Number { get; set; }
        public byte[] RowVersion { get; set; }
        public Person Person { get; set; }
    }

    public class Address
    {
        public String First { get; set; }
        public String Second { get; set; }
    }

    public class TestConofiguration : EntityTypeConfiguration<Person>
    {
        public TestConofiguration()
        {
            ToTable("Person");
            HasKey(e => e.Name);
        }
    }

    public class TelConfiguration : EntityTypeConfiguration<Tel>
    {
        public TelConfiguration() {
            ToTable("Tel");
            HasKey(e => e.Number);
            Property(e => e.RowVersion).IsRowVersion();
        }
    }

    public class AddressConfiguration : ComplexTypeConfiguration<Address>
    {
        public AddressConfiguration()
        {

        }
    }
}
