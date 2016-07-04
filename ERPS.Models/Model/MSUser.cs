#region
/***********************************************
 * 
 * 
 * ********************************************/
#endregion
using Infrastructure;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace ERPS.Models
{
    public class MSUser:EntityBase,IAggregateRoot
    {
        public String Name { get; set; }
        public String Pwd { get; set; }
        public Sex Sex { get; set; }
        public String ContactNumber { get; set; }
        public String Email { get; set; }
        public MSRole MSRole { get; set; }
        public byte[] MSImage { get; set; }

        protected override void Validate()
        {
            throw new NotImplementedException();
        }
    }

    public enum MSRole
    {
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
