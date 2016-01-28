using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Text.RegularExpressions;
using System.Windows.Input;
using System.Windows.Forms;
using System.Drawing;
using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.VisualStudio.TestTools.UITest.Extension;
using Keyboard = Microsoft.VisualStudio.TestTools.UITesting.Keyboard;
using System.Linq;
using System.Text;
using ERP.Infrastructure;
using ERP.Repository;
using ERP.Models;


namespace UnitTest
{
    /// <summary>
    /// CodedUITest1 的摘要说明
    /// </summary>
    [CodedUITest]
    public class RepositoryTest
    {
        public RepositoryTest()
        {
        }

        [TestMethod]
        public void MSRoleRepositoryTest()
        {
            MSRole r1 = new MSRole() { RoleId = System.Guid.NewGuid(), RoleName = "测试用户1" };
            MSRole r2 = new MSRole() { RoleId = System.Guid.NewGuid(), RoleName = "测试用户2" };
            using (IEFUnitOfWork unitOfWork = new EFUnitOfWork())
            {
                IMSRoleRepository msRoleRepository = new MSRoleUnitOfWorkRepository();
                msRoleRepository.UnitOfWork = unitOfWork;
                msRoleRepository.Add(r1);
                msRoleRepository.Add(r2);
                unitOfWork.Commit();
            }

            //dbContext = new DataContext();
            using (IEFUnitOfWork unitOfWork = new EFUnitOfWork())
            {
                IMSRoleRepository msRoleRepository = new MSRoleUnitOfWorkRepository();
                msRoleRepository.UnitOfWork = unitOfWork;
                List<MSRole> l1 = msRoleRepository.GetAll().ToList();
                Assert.IsTrue(l1.Count == 2);
                unitOfWork.Commit();
            }

            //dbContext = new DataContext();
            using (IEFUnitOfWork unitOfWork = new EFUnitOfWork())
            {
                IMSRoleRepository msRoleRepository = new MSRoleUnitOfWorkRepository();
                msRoleRepository.UnitOfWork = unitOfWork;
                MSRole ur = msRoleRepository.GetAll().Where(it => it.RoleName.Equals("测试用户1")).FirstOrDefault();
                Assert.IsTrue(ur != null);
                ur.RoleName = "测试用户3";
                msRoleRepository.Save(ur);
                unitOfWork.Commit();
            }

            //dbContext = new DataContext();
            using (IEFUnitOfWork unitOfWork = new EFUnitOfWork())
            {
                IMSRoleRepository msRoleRepository = new MSRoleUnitOfWorkRepository();
                msRoleRepository.UnitOfWork = unitOfWork;
                MSRole u3 = msRoleRepository.GetAll().Where(it => it.RoleName.Equals("测试用户3")).FirstOrDefault();
                Assert.IsTrue(u3 != null);
                List<MSRole> lt = msRoleRepository.GetAll().ToList();
                Assert.IsTrue(lt.Count == 2);
                foreach (var item in lt)
                {
                    msRoleRepository.Remove(item);
                }
                unitOfWork.Commit();
            }

            //dbContext = new DataContext();
            using (IEFUnitOfWork unitOfWork = new EFUnitOfWork())
            {
                IMSRoleRepository msRoleRepository = new MSRoleUnitOfWorkRepository();
                msRoleRepository.UnitOfWork = unitOfWork;
                Assert.IsTrue(msRoleRepository.GetAll().ToList().Count <= 0);
                unitOfWork.Commit();
            }
        }

        [TestMethod]
        public void MSUserRepositoryTest()
        {

            MSRole role1 = new MSRole() { RoleId = System.Guid.NewGuid(), RoleName = "测试用户角色1" };
            MSRole role2 = new MSRole() { RoleId = System.Guid.NewGuid(), RoleName = "测试用户角色2" };
            MSRole role3 = new MSRole() { RoleId = System.Guid.NewGuid(), RoleName = "测试用户角色3" };
            MSUser user = new MSUser() { UserId = System.Guid.NewGuid(), UserName = "测试用户名1", Password = "ms", MSRole = role1 };
            MSUser user2 = new MSUser() { UserId = System.Guid.NewGuid(), UserName = "测试用户名2", Password = "ms", MSRole = role3 };

            DataContext dbContext = new DataContext();
            using (IEFUnitOfWork unitOfWork = new EFUnitOfWork())
            {
                IMSUserRepository msUserRepository = new MSUserUnitOfWorkRepository();
                msUserRepository.UnitOfWork = unitOfWork;
                msUserRepository.Add(user);
                msUserRepository.Add(user2);
                unitOfWork.Commit();
            }

            //dbContext = new DataContext();
            using (IEFUnitOfWork unitOfWork = new EFUnitOfWork())
            {
                IMSUserRepository msUserRepository = new MSUserUnitOfWorkRepository();
                msUserRepository.UnitOfWork = unitOfWork;
                Assert.IsTrue(msUserRepository.GetAll().Count() > 0);
                unitOfWork.Commit();
            }

            using (IEFUnitOfWork unitOfWork = new EFUnitOfWork())
            {
                IMSUserRepository msUserRepository = new MSUserUnitOfWorkRepository();
                msUserRepository.UnitOfWork = unitOfWork;
                MSUser u = msUserRepository.GetAll().Where(it => it.UserName == "测试用户名1").FirstOrDefault();
                u.MSRole = role2;
                msUserRepository.Save(u);
                unitOfWork.Commit();
            }

            //dbContext = new DataContext();
            using (IEFUnitOfWork unitOfWork = new EFUnitOfWork())
            {
                IMSUserRepository msUserRepository = new MSUserUnitOfWorkRepository();
                msUserRepository.UnitOfWork = unitOfWork;
                MSUser ul = msUserRepository.GetAll().Include("MSRole").Where(it => it.UserName == "测试用户名1").FirstOrDefault();
                Assert.IsTrue(ul.MSRole.Equals(role2));
                unitOfWork.Commit();
            }


            //dbContext = new DataContext();
            using (IEFUnitOfWork unitOfWork = new EFUnitOfWork())
            {
                IMSUserRepository msUserRepository = new MSUserUnitOfWorkRepository();
                IMSRoleRepository msRoleRepository = new MSRoleUnitOfWorkRepository();
                msUserRepository.UnitOfWork = unitOfWork;
                msRoleRepository.UnitOfWork = unitOfWork;
                MSUser ul = msUserRepository.GetAll().Include("MSRole").Where(it => it.UserName == "测试用户名1").FirstOrDefault();
                MSRole r1 = msRoleRepository.GetAll().Where(it => it.RoleName == "测试用户角色1").FirstOrDefault();
                ul.MSRole = r1;
                msUserRepository.Save(ul);
                unitOfWork.Commit();
            }


            //dbContext = new DataContext();
            using (IEFUnitOfWork unitOfWork = new EFUnitOfWork())
            {
                IMSUserRepository msUserRepository = new MSUserUnitOfWorkRepository();
                msUserRepository.UnitOfWork = unitOfWork;
                MSUser ul = msUserRepository.GetAll().Include("MSRole").Where(it => it.UserName == "测试用户名1").FirstOrDefault();
                Assert.IsTrue(ul.MSRole.Equals(role1));
                unitOfWork.Commit();
            }

            //dbContext = new DataContext();
            using (IEFUnitOfWork unitOfWork = new EFUnitOfWork())
            {
                IMSUserRepository msUserRepository = new MSUserUnitOfWorkRepository();
                IMSRoleRepository msRoleRepository = new MSRoleUnitOfWorkRepository();
                msUserRepository.UnitOfWork = null;
                msRoleRepository.UnitOfWork = unitOfWork;
                //msUserRepository.Remove(.FirstOrDefault());
                foreach (var item in msUserRepository.GetAll().ToList())
                {
                    msUserRepository.Remove(item);
                }
                foreach (var item in msRoleRepository.GetAll().ToList())
                {
                    msRoleRepository.Remove(item);
                }
                unitOfWork.Commit();
            }

        }

        [TestMethod]
        public void InitTest()
        {
            DataBaseHelper.InintDataBase();
        }

        #region 附加测试特性

        // 编写测试时，可以使用以下附加特性:

        ////运行每项测试之前使用 TestInitialize 运行代码 
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{        
        //    // 若要为此测试生成代码，请从快捷菜单中选择“为编码的 UI 测试生成代码”，然后选择菜单项之一。
        //    // 有关生成的代码的详细信息，请参见 http://go.microsoft.com/fwlink/?LinkId=179463
        //}

        ////运行每项测试之后使用 TestCleanup 运行代码
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{        
        //    // 若要为此测试生成代码，请从快捷菜单中选择“为编码的 UI 测试生成代码”，然后选择菜单项之一。
        //    // 有关生成的代码的详细信息，请参见 http://go.microsoft.com/fwlink/?LinkId=179463
        //}

        #endregion

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
        private TestContext testContextInstance;
    }
}
