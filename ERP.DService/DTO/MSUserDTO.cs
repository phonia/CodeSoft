using ERP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ERP.DService
{
    public class MSUserDTO
    {
        public string RoleName { get; set; }

        public string UserName { get; set; }

        public Guid UserId { get; set; }

        public String Passworld { get; set; }
    }
}
