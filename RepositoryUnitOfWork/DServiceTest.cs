using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Practices.Unity;
using ERP.Models;
using ERP.Repository;
using ERP.Infrastructure;
using ERP.DService;
using Microsoft.Practices.Unity.InterceptionExtension;

namespace RepositoryUnitOfWork
{
    /// <summary>
    /// DServiceTest 的摘要说明
    /// </summary>
    [TestClass]
    public class DServiceTest
    {

        private MSUserService service1 = null;
        private System.Guid id = System.Guid.Empty;

        public DServiceTest()
        {
            try
            {
                IUnityContainer unity = new UnityContainer();
                unity.AddNewExtension<Interception>();
                unity.RegisterType<IMSUserRepository, MSUserUnitOfWorkRepository>();
                unity.RegisterType<IUnitOfWork, EFUnitOfWork>();
                unity.RegisterType<IMSRoleRepository, MSRoleUnitOfWorkRepository>();
                unity.RegisterType<IMSRightRepository, MSRightUnitOfWorkRepository>();
                unity.RegisterType<MSUserService>(
                    new Interceptor<VirtualMethodInterceptor>(),
                    new InterceptionBehavior<ValidationInterceptor>()
                    );
                AutoMapperBootStrapper.Start();
                service1 = (MSUserService)unity.Resolve(typeof(MSUserService));
            }
            catch (Exception ex)
            { }

            //service2 = (MSUserService)unity.Resolve(typeof(MSUserService));
        }

        private TestContext testContextInstance;

        /// <summary>
        ///获取或设置测试上下文，该上下文提供
        ///有关当前测试运行及其功能的信息。
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region 附加测试特性
        //
        // 编写测试时，可以使用以下附加特性:
        //
        // 在运行类中的第一个测试之前使用 ClassInitialize 运行代码
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // 在类中的所有测试都已运行之后使用 ClassCleanup 运行代码
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // 在运行每个测试之前，使用 TestInitialize 来运行代码
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // 在每个测试运行完之后，使用 TestCleanup 来运行代码
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void MSUserTest()
        {
            /*
             * 注册角色
             * **/
            MSRoleDTO msRoleDTO1 = new MSRoleDTO() { RoleName = "超级管理员" };
            MSRoleDTO msRoleDTO2 = new MSRoleDTO()
            {
                RoleName = "注册用户"
            };

            Assert.IsTrue(service1.GetAllRights().Count >=2);
            List<MSRightDTO> rights = service1.GetAllRights();

            service1.RegiseterRole(msRoleDTO1, rights.Select(it=>System.Guid.Parse(it.RightId)).ToList());
            service1.RegiseterRole(msRoleDTO2, new List<System.Guid>() { System.Guid.Parse(rights[0].RightId) });
            Assert.IsTrue(service1.GetAllMSRoles().Count>=2);

            
            /*
             * 修改角色权限
             * **/
            service1.UpdateMSRoleRight(msRoleDTO2.RoleId, new List<System.Guid>() { System.Guid.Parse(rights[0].RightId),System.Guid.Parse(rights[1].RightId)});
            Assert.IsTrue(service1.GetMSRoleRight(msRoleDTO2.RoleId).Count >= 2);

            service1.UpdateMSRoleRight(msRoleDTO2.RoleId, new List<System.Guid>() { System.Guid.Parse(rights[0].RightId) });
            /**
             * 测试 角色权限为空
             * **/
            service1.UpdateMSRoleRight(msRoleDTO2.RoleId, new List<Guid>());
            Assert.IsTrue(service1.GetMSRoleRight(msRoleDTO2.RoleId).Count <= 0);


            /*
             * 添加用户
             * **/
            MSUserDTO msUserDTO1 = new MSUserDTO() { UserName = "admin", Passworld = "admin", RoleName = "超级管理员" };
            MSUserDTO msUserDTO2 = new MSUserDTO() { UserName = "hy", Passworld = "hy", RoleName = "注册用户" };
            service1.RegisterMSUser(msUserDTO1);
            service1.RegisterMSUser(msUserDTO2);
            Assert.IsTrue(service1.GetAllMSUser().Count >= 2);

            /*
             * 修改用户
             * **/
            service1.UpdateMSUserRole(msUserDTO2.UserId, msRoleDTO1.RoleId);
            Assert.IsTrue(service1.GetMSUser(msUserDTO2.UserId).RoleName.Equals(msRoleDTO1.RoleName));
            service1.UpdateMSUserRole(msUserDTO2.UserId, msRoleDTO2.RoleId);



            /*
             * 删除用户
             * **/
            service1.RemoveMSUser(msUserDTO1.UserId);
            service1.RemoveMSUser(msUserDTO2.UserId);

            /*
             * 删除角色
             * **/
            service1.RemvoeMSRole(msRoleDTO2.RoleId);
            service1.RemvoeMSRole(msRoleDTO1.RoleId);
        }
    }
}
