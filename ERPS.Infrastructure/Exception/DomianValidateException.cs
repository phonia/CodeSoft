using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infrastructure
{
    public class DomianValidateException:Exception
    {
        public DomianValidateException(String message) : base(message) { }
    }
}
