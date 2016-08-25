using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace EPRS.Service
{
    public partial class PositionDTO
    {
        [Description("部门Id")]
        public int DepartmentId { get; set; }
        [Description("部门名称")]
        public String DepartmentName { get; set; }
    }
}
