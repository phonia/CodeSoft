using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERPS.WebUI.Interceptor
{
    public class UserPermissonException:Exception
    {
        public UserPermissonException(String message)
            : base(message)
        { }
    }
}