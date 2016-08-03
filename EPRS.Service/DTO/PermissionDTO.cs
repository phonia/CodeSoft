using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EPRS.Service
{
    public class PermissionDTO
    {
        public Int32 id { get; set; }
        public String text { get; set; }
        public String state { get; set; }
        public attributes attributes { get; set; }
        public String iconCls { get; set; }
    }

    public class attributes
    {
        public int isMenu { get; set; }
    }
}
