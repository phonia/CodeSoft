using EPRS.Repository;
using EPRS.Service;
using ERPS.Models;
using ERPS.WebUI.Interceptor;
using Infrastructure;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.InterceptionExtension;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ERPS.WebUI.Controllers
{
    public class UnityControllerFactory:DefaultControllerFactory
    {
        public UnityBootStrapper _unityBootStrapper = null;

        public UnityControllerFactory()
        {
            _unityBootStrapper = new UnityBootStrapper();
            _unityBootStrapper.Bindings();
        }

        protected override IController GetControllerInstance(System.Web.Routing.RequestContext requestContext, Type controllerType)
        {
            //if (requestContext.HttpContext.Session["MSUserDTO"] != null)
            //{
            //    _unityBootStrapper.UnityContainer.RegisterType<UserPermissonValidateInterceptor>
            //        (new InjectionProperty("MSUserDTO", (MSUserDTO)requestContext.HttpContext.Session["MSUserDTO"]));
            //}
            //else
            //{
            //    _unityBootStrapper.UnityContainer.RegisterType<UserPermissonValidateInterceptor>
            //        (new InjectionProperty("MSUserDTO", new MSUserDTO()));
            //}
            return controllerType == null ? null : (IController)_unityBootStrapper.UnityContainer
                .Resolve(controllerType);
        }

        public override void ReleaseController(IController controller)
        {
            _unityBootStrapper.UnityContainer.Teardown(controller);
        }
    }

    public class UnityBootStrapper
    {
        public IUnityContainer UnityContainer = new UnityContainer();

        public void Bindings()
        {
            UnityContainer.AddNewExtension<Interception>();
            //UnityContainer.RegisterType<IMSUserRepository, MSUserRepository>();
            UnityContainer.RegisterType<IUnitOfWork, EFUnitOfWork>();
            UnityContainer.RegisterType<IDepartmentRepository, DepartmentRepository>();
            UnityContainer.RegisterType<IErrorLogRepository, ErrorLogRepository>();
            UnityContainer.RegisterType<IMenuInfoRepository, MenuInfoRepository>();
            //UnityContainer.RegisterType<IPagePowerSignRepository, PagePowerSignRepository>();
            UnityContainer.RegisterType<IActionPermissionRepository, ActionPermissionRepository>();
            UnityContainer.RegisterType<IPositionRepository, PositionRepository>();
            UnityContainer.RegisterType<ISUserRepository, SUserRepository>();
            UnityContainer.RegisterType<IWebConfigRepository, WebConfigRepository>();
            UnityContainer.RegisterType<IAppInstallService, AppInstall>();

            UnityContainer.RegisterType<IMenuInfoService, MenuInfoService>(
                    new Interceptor<InterfaceInterceptor>(),
                    new InterceptionBehavior<ArgumentValidateInterceptor>(),
                    new InterceptionBehavior<UserPermissonValidateInterceptor>()
                );
            UnityContainer.RegisterType<IUserService, UserService>(
                    new Interceptor<InterfaceInterceptor>(),
                    new InterceptionBehavior<ArgumentValidateInterceptor>(),
                    new InterceptionBehavior<UserPermissonValidateInterceptor>()
                );
            //UnityContainer.RegisterType<IMSUserService, MSUserService>(
            //    new Interceptor<InterfaceInterceptor>(),
            //    new InterceptionBehavior<ArgumentValidateInterceptor>(),
            //    new InterceptionBehavior<UserPermissonValidateInterceptor>()
            //    );
        }
    }
}