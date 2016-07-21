

/***********************************************
 * auto-generated code from T4
 * 
 * ********************************************/



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

        public DataContext() : base("DataContext") { 
			base.Configuration.LazyLoadingEnabled = false;
		}

        public DataContext(String connectionStrings) : base(connectionStrings) { }
        ///<summary>
        ///系统基本参数
        ///</summary>
        public DbSet<WebConfig> WebConfigSets { get; set; }

        ///<summary>
        ///菜单表
        ///</summary>
        public DbSet<MenuInfo> MenuInfoSets { get; set; }

        ///<summary>
        ///操作权限
        ///</summary>
        public DbSet<ActionPermission> ActionPermissionSets { get; set; }

        ///<summary>
        ///用户表
        ///</summary>
        public DbSet<SUser> SUserSets { get; set; }

        ///<summary>
        ///部门
        ///</summary>
        public DbSet<Department> DepartmentSets { get; set; }

        ///<summary>
        ///职务
        ///</summary>
        public DbSet<Position> PositionSets { get; set; }

        ///<summary>
        ///用户日志
        ///</summary>
        public DbSet<UserLog> UserLogSets { get; set; }

        ///<summary>
        ///异常日志
        ///</summary>
        public DbSet<ErrorLog> ErrorLogSets { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
			//Database.Delete("DataContext");
            modelBuilder.Configurations.Add(new WebConfigConfiguration());
            modelBuilder.Configurations.Add(new MenuInfoConfiguration());
            modelBuilder.Configurations.Add(new ActionPermissionConfiguration());
            modelBuilder.Configurations.Add(new SUserConfiguration());
            modelBuilder.Configurations.Add(new PersonInfoConfiguration());
            modelBuilder.Configurations.Add(new OnLineInfoConfiguration());
            modelBuilder.Configurations.Add(new DepartmentConfiguration());
            modelBuilder.Configurations.Add(new PositionConfiguration());
            modelBuilder.Configurations.Add(new UserLogConfiguration());
            modelBuilder.Configurations.Add(new ErrorLogConfiguration());
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<DataContext>());
        }

        public static void InitDataBase()
        {
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<DataContext>());
        }
    }
}