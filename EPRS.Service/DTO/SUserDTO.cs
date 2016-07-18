using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EPRS.Service
{
    public partial class SUserDTO
    {
        public int PositionId { get; set; }
        public String PositionName { get; set; }

        public int DepartmentId { get; set; }
        public String DepartmentName { get; set; }
    }
}
