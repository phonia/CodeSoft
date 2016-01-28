using Microsoft.Practices.Unity.InterceptionExtension;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace ERP.Infrastructure
{
    public abstract class ArgumentValidationAttribute: Attribute
    {
        public abstract void Validate(object value, string argumentName);
    }

    [AttributeUsage(AttributeTargets.Parameter)]
    public class NotNullAttribute : ArgumentValidationAttribute
    {
        public override void Validate(object value, string argumentName)
        {
            if (value == null) throw new ArgumentNullException(argumentName);
        }
    }

    public class ValidationInterceptor : IInterceptionBehavior
    {

        public IEnumerable<Type> GetRequiredInterfaces()
        {
            return this.GetType().GetInterfaces();
        }

        public IMethodReturn Invoke(IMethodInvocation input, GetNextInterceptionBehaviorDelegate getNext)
        {
            string className = input.MethodBase.DeclaringType.Name;
            ParameterInfo[] parms = input.MethodBase.GetParameters();
            if (parms == null || parms.Length <= 0) return getNext()(input, getNext);
            for (int index = 0; index < parms.Length; index++)
            {
                var attrs = parms[index].GetCustomAttributes(false);
                if (attrs == null || attrs.Length <= 0) continue;
                foreach (var attr in attrs)
                {
                    if (attr is ArgumentValidationAttribute)
                    {
                        (attr as ArgumentValidationAttribute).Validate(input.Arguments[index], "Class:"+className + ",Method" + input.MethodBase.Name + ",Parameter" + parms[index].Name);
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
