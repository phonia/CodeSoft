using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EPRS.Repository;
using ERPS.Models;

namespace ERPS.UnitTest
{
    /// <summary>
    /// RepositoryTest 的摘要说明
    /// </summary>
    [TestClass]
    public class RepositoryTest
    {
        public RepositoryTest()
        {
            //
            //TODO: 在此处添加构造函数逻辑
            //
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

        #region AbandonTest
        //[TestMethod]
        //public void MSUserTest()
        //{
        //    MSUser msUser = new MSUser { ContactNumber = "000-000000", Email = "hy@hy.com", MSRole = MSRole.SysManager, Name = "HyRepositoryTest", Pwd = "polan", Sex = Sex.Female ,MSImage=new byte[10]};
        //    //增
        //    try
        //    {
        //        using (IEFUnitOfWork unitOfWork = new EFUnitOfWork())
        //        {
        //            IMSUserRepository msUserRepository = new MSUserRepository();
        //            msUserRepository.UnitOfWork = unitOfWork;
        //            msUserRepository.Add(msUser);
        //            unitOfWork.Commit();
        //        }
        //    }
        //    catch (Exception ex)
        //    { }
        //    //查
        //    using (IEFUnitOfWork unitOfWork = new EFUnitOfWork())
        //    {
        //        IMSUserRepository msUserRepository = new MSUserRepository();
        //        msUserRepository.UnitOfWork = unitOfWork;
        //        Assert.IsTrue(msUserRepository.GetAll().Count() > 0);
        //    }
        //    //改
        //    using (IEFUnitOfWork unitOfWork = new EFUnitOfWork())
        //    {
        //        IMSUserRepository msUserRepository = new MSUserRepository();
        //        msUserRepository.UnitOfWork = unitOfWork;
        //        msUser.Pwd = "HyRepositoryTest";
        //        msUserRepository.Save(msUser);
        //        unitOfWork.Commit();
        //    }
        //    //删除
        //    using (IEFUnitOfWork unitOfWork = new EFUnitOfWork())
        //    {
        //        IMSUserRepository msUserRepository = new MSUserRepository();
        //        msUserRepository.UnitOfWork = unitOfWork;
        //        msUserRepository.Remove(msUser);
        //        unitOfWork.Commit();
        //    }

        //}
        #endregion

        [TestMethod]
        public void WebConfigRepositoryTest()
        {
            WebConfig webConfig = new WebConfig()
            {
                EmailDomain = ".com.cn",
                EmailPassWord = "polan",
                EmailSmtp = "smtp@smtp.com",
                EmailUserName = "hy",
                LoginLogReserveTime = 1,
                UseLogReserveTime = 1,
                WebDomain = "www.bb.com",
                WebEmail = "www.bb.com",
                WebName = "bb"
            };

            using (var unitOfWork = new EFUnitOfWork())
            {
                IWebConfigRepository webConfigRepository = new WebConfigRepository();
                webConfigRepository.UnitOfWork = unitOfWork;
                webConfigRepository.Add(webConfig);
                unitOfWork.Commit();
            }

            using (var unitOfWork = new EFUnitOfWork())
            {
                IWebConfigRepository webConfigRepository = new WebConfigRepository();
                webConfigRepository.UnitOfWork = unitOfWork;
                webConfig= webConfigRepository.GetAll().Where(it => it.EmailUserName.Equals("hy")).FirstOrDefault();
                unitOfWork.Commit();
            }
            Assert.IsNotNull(webConfig);

            using (var unitOfWork = new EFUnitOfWork())
            {
                IWebConfigRepository webConfigRepository = new WebConfigRepository();
                webConfigRepository.UnitOfWork = unitOfWork;
                var justwe = webConfigRepository.GetAll().Where(it => it.EmailUserName.Equals("hy")).FirstOrDefault();
                justwe.WebName = "yy";
                webConfigRepository.Save(justwe);
                unitOfWork.Commit();
            }

            using (var unitOfWork = new EFUnitOfWork())
            {
                IWebConfigRepository webConfigRepository = new WebConfigRepository();
                webConfigRepository.UnitOfWork = unitOfWork;
                var justwe = webConfigRepository.GetAll().Where(it => it.WebName.Equals("yy")).FirstOrDefault();
                Assert.IsNotNull(justwe);
                unitOfWork.Commit();
            }

            using (var unitOfWork = new EFUnitOfWork())
            {
                IWebConfigRepository webConfigRepository = new WebConfigRepository();
                webConfigRepository.UnitOfWork = unitOfWork;
                webConfigRepository.RemoveNonCascaded(webConfig.Id);
                unitOfWork.Commit();
            }

            using (var unitOfWork = new EFUnitOfWork())
            {
                IWebConfigRepository webConfigRepository = new WebConfigRepository();
                webConfigRepository.UnitOfWork = unitOfWork;
                var justwe = webConfigRepository.GetAll().Count();
                Assert.IsTrue(justwe <= 0);
                unitOfWork.Commit();
            }
        }
    }
}
