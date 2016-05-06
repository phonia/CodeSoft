using Microsoft.Practices.Unity.InterceptionExtension;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERPS.WebUI.Interceptor
{
    public class UserPermissonValidateInterceptor : IInterceptionBehavior
    {
        public IEnumerable<Type> GetRequiredInterfaces()
        {
            throw new NotImplementedException();
        }

        public IMethodReturn Invoke(IMethodInvocation input, GetNextInterceptionBehaviorDelegate getNext)
        {
            throw new NotImplementedException();
        }

        public bool WillExecute
        {
            get { throw new NotImplementedException(); }
        }
    }
}