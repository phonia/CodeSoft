//using ERPS.Models;
//using System;
//using System.Collections.Generic;
//using System.Data.Entity;
//using System.Linq;
//using System.Text;

//namespace EPRS.Repository
//{
//    public class DataContext:DbContext,IDisposable
//    {

//        public DataContext() : base("DataContext") { }

//        public DataContext(String connectionStrings) : base(connectionStrings) { }

//        public DbSet<MSUser> MSUser { get; set; }
//        public DbSet<WebConfig> WebConfig { get; set; }
//        public DbSet<MenuInfo> MenuInfo { get; set; }
//        public DbSet<PagePowerSign> PagePowerSign { get; set; }
//        public DbSet<SUser> User { get; set; }
//        //public DbSet<PersonInfo> PersonInfo { get; set; }

//        protected override void OnModelCreating(DbModelBuilder modelBuilder)
//        {
//            modelBuilder.Configurations.Add(new MSUserConfiguration());
//            modelBuilder.Configurations.Add(new WebConfigConfiguration());
//            modelBuilder.Configurations.Add(new MenuInfoConfiguration());
//            modelBuilder.Configurations.Add(new PagePowerSignConfiguration());
//            modelBuilder.Configurations.Add(new SUserConfiguration());
//            modelBuilder.Configurations.Add(new PersonInfoConfiguration());
//            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<DataContext>());
//        }

//        public static void InitDataBase()
//        {
//            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<DataContext>());
//        }
//    }
//}
