using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ERPS.Infrastructure
{
    public class DomainServiceException:Exception
    {
        public DomainServiceException(string message) : base(message) { }
    }
}
