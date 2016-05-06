using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infrastructure
{
    public abstract class ArgumentValidationAttribute:Attribute
    {
        public abstract void Validate(Object value, String argumentName);
    }

    [AttributeUsage(AttributeTargets.Parameter)]
    public class NotNullAttribute : ArgumentValidationAttribute
    {
        public override void Validate(object value, string argumentName)
        {
            if (value is Nullable) throw new ArgumentNullException(argumentName, "参数不能为空！");
        }
    }
}
