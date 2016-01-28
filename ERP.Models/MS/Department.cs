using ERP.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ERP.Models
{
    public partial class Department:EntityBase,IAggregateRoot
    {
        protected override void Validate()
        {
            if (string.IsNullOrWhiteSpace(this.DepartmentName)) AddBrokenRule(new BusinessRule() { Propery = "Name", Rule = "部门名称不为空" });
        }
    }

    public interface IDepartmentRepository : IRepository<Department,System.Guid>
    { }
}
