using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ERP.Infrastructure
{
    public interface ILog
    {
        void WriteLog(String message);
    }
}
