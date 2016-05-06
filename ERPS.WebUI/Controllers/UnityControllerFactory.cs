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
        private IUnityContainer _unityContainer;

        public UnityControllerFactory()
        {
            _unityContainer = new UnityContainer();
            Bindings();
        }

        protected override IController GetControllerInstance(System.Web.Routing.RequestContext requestContext, Type controllerType)
        {
            return controllerType == null ? null : (IController)_unityContainer.Resolve(controllerType);
        }

        public override void ReleaseController(IController controller)
        {
            _unityContainer.Teardown(controller);
        }

        void Bindings()
        {
            _unityContainer.AddNewExtension<Interception>();
            _unityContainer.RegisterType<IMSUserRepository, MSUserRepository>();
            _unityContainer.RegisterType<IUnitOfWork, EFUnitOfWork>();
            //_unityContainer.RegisterType<IMSUserService, MSUserService>();
            _unityContainer.RegisterType<IMSUserService, MSUserService>(
                new Interceptor<InterfaceInterceptor>(),
                new InterceptionBehavior<ArgumentValidateInterceptor>()
                );
        }
    }
}