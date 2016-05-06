using Microsoft.Practices.Unity.InterceptionExtension;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERPS.WebUI.Interceptor
{
    public class UserOperatorLogInterceptor : IInterceptionBehavior
    {
        public IEnumerable<Type> GetRequiredInterfaces()
        {
            return this.GetType().GetInterfaces();
        }

        public IMethodReturn Invoke(IMethodInvocation input, GetNextInterceptionBehaviorDelegate getNext)
        {
            throw new NotImplementedException();
        }

        public bool WillExecute
        {
            get { return true; }
        }
    }
}