using ERP.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ERP.Models
{
    public partial class MSRole:EntityBase,IAggregateRoot
    {
        protected override void Validate()
        {
            if (String.IsNullOrWhiteSpace(this.RoleName)) AddBrokenRule(new BusinessRule() {Propery="RoleName",Rule="角色名不能为空" });
        }
    }
}
