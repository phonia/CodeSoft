using ERP.DService;
using ERP.Infrastructure;
using ERP.Models;
using ERP.Repository;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.InterceptionExtension;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERP.WebUI
{
    public class ServiceFactory
    {
        private IUnityContainer _unity = new UnityContainer();

        public ServiceFactory()
        {
            _unity.AddNewExtension<Interception>();
            _unity.RegisterType<IMSUserRepository, MSUserUnitOfWorkRepository>();
            _unity.RegisterType<IUnitOfWork, EFUnitOfWork>();
            _unity.RegisterType<IMSRoleRepository, MSRoleUnitOfWorkRepository>();
            _unity.RegisterType<IMSRightRepository, MSRightUnitOfWorkRepository>();
            _unity.RegisterType<IMSDomainRepository, MSDomainRepository>();
            _unity.RegisterType<IMSModuleRepository, MSModuleRepository>();
            _unity.RegisterType<MSUserService>(
                new Interceptor<VirtualMethodInterceptor>(),
                new InterceptionBehavior<ValidationInterceptor>()
                );
            //AutoMapperBootStrapper.Start();
            //service1 = (MSUserService)unity.Resolve(typeof(MSUserService));
        }

        public T GetService<T>()
        {
            return (T)_unity.Resolve(typeof(T));
        }
    }
}