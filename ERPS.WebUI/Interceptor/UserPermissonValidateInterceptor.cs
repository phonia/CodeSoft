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
        [Dependency]
        public MSUserDTO MSUserDTO { get; set; }

        public IEnumerable<Type> GetRequiredInterfaces()
        {
            return this.GetType().GetInterfaces();
        }

        public IMethodReturn Invoke(IMethodInvocation input, GetNextInterceptionBehaviorDelegate getNext)
        {
            String className = input.MethodBase.DeclaringType.Name;
            Attribute[] attrs = (Attribute[])input.MethodBase.GetCustomAttributes(false);
            if (attrs == null || attrs.Length <= 0) return getNext()(input, getNext);
            foreach (var node in attrs)
            {
                if (node is UserPermissionAttribute)
                {
                    if ((node as UserPermissionAttribute).IsPermisson(MSUserDTO)) break;
                    else {
                        throw new UserPermissonException("没有操作权限！");
                    }
                }
            }
            return getNext()(input, getNext);
        }

        public bool WillExecute
        {
            get { return true; }
        }
    }
}