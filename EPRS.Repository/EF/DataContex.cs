using ERPS.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace EPRS.Repository
{
    public class DataContext:DbContext,IDisposable
    {

        public DataContext() : base("DataContext") { }

        public DataContext(String connectionStrings) : base(connectionStrings) { }

        public DbSet<MSUser> MSUser { get; set; }
        public DbSet<WebConfig> WebConfig { get; set; }
        public DbSet<Person> Person { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new MSUserConfiguration());
            modelBuilder.Configurations.Add(new WebConfigConfiguration());
            modelBuilder.Configurations.Add(new TestConofiguration());
            modelBuilder.Configurations.Add(new AddressConfiguration());
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<DataContext>());
        }

        public static void InitDataBase()
        {
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<DataContext>());
        }
    }
}
