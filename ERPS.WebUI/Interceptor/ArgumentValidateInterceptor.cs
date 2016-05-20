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
                if (parms[index].ParameterType == typeof(System.String))
                {
                    if (input.Inputs[index] == null) throw new DomianValidateException(className+"-"+parms[index].Name+"不能为空");
                    if (String.IsNullOrWhiteSpace(input.Inputs[index].ToString())) throw new DomianValidateException(className + "-" + parms[index].Name + "不能为空");
                }
                if (!parms[index].ParameterType.IsValueType && input.Inputs[index] == null)
                {
                    throw new DomianValidateException(className + "-" + parms[index].Name + "不能为空");
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