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

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new MSUserConfiguration());
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<DbContext>());
        }

        public static void InitDataBase()
        {
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<DbContext>());
        }
    }
}
