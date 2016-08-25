using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace EPRS.Service
{
    public partial class SUserDTO
    {
        [Description("职位Id")]
        public int PositionId { get; set; }
        [Description("职位名称")]
        public String PositionName { get; set; }
        [Description("部门Id")]
        public int DepartmentId { get; set; }
        [Description("部门名称")]
        public String DepartmentName { get; set; }

    }
}
