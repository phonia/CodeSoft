using EPRS.Service;
using Infrastructure;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.InterceptionExtension;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;

namespace ERPS.WebUI.Interceptor
{
    public class ArgumentValidateInterceptor:IInterceptionBehavior
    {
        public IEnumerable<Type> GetRequiredInterfaces()
        {
            return this.GetType().GetInterfaces();
        }

        public IMethodReturn Invoke(IMethodInvocation input, GetNextInterceptionBehaviorDelegate getNext)
        {
            String className = input.MethodBase.DeclaringType.Name;
            ParameterInfo[] parms = input.MethodBase.GetParameters();
            if (parms == null || parms.Length<=0) return getNext()(input, getNext);

            for (int index = 0; index < parms.Length; index++)
            {
                var attrs = parms[index].GetCustomAttributes(false);
                if (attrs == null || attrs.Length <= 0) continue;
                foreach (var node in attrs)
                {
                    if (node is ArgumentValidationAttribute)
                    {
                        (node as ArgumentValidationAttribute).Validate(input.Arguments[index], "Class:" + className + ",Method" + input.MethodBase.Name + ",Parameter:" + parms[index].Name);
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