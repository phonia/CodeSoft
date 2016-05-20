using EPRS.Service;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.InterceptionExtension;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERPS.WebUI.Interceptor
{
    public class UserPermissonValidateInterceptor : IInterceptionBehavior
    {
        public MSUserDTO MSUserDTO { get; set; }

        public IEnumerable<Type> GetRequiredInterfaces()
        {
            return this.GetType().GetInterfaces();
        }

        public IMethodReturn Invoke(IMethodInvocation input, GetNextInterceptionBehaviorDelegate getNext)
        {
            //根据调用类名以及方法名判断与用户信息判断是否具有权限

            //String className = input.MethodBase.DeclaringType.Name;
            //Attribute[] attrs = (Attribute[])input.MethodBase.GetCustomAttributes(false);
            //if (attrs == null || attrs.Length <= 0) return getNext()(input, getNext);
            //foreach (var node in attrs)
            //{
            //    //
            //}
            return getNext()(input, getNext);
        }

        public bool WillExecute
        {
            get { return true; }
        }
    }
}