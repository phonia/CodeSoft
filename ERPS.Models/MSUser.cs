using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace ERPS.Models
{
    public class MSUser
    {
        public String Name { get; set; }
        public String Pwd { get; set; }
        public Sex Sex { get; set; }
        public String ContactNumber { get; set; }
        public String Email { get; set; }
        public MSRole MSRole { get; set; }
    }

    public enum MSRole
    {
        [Description("销售员")]
        SalesMan, 
        Developer, 
        WarehouseKeeper,
        Buyer,
        SysManager
    }

    public enum Sex
    {
        Male,Female,Unknown
    }
}
