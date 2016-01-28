using ERP.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ERP.Models
{
    public partial class Employee:EntityBase,IAggregateRoot
    {
        protected override void Validate()
        {
            if (string.IsNullOrWhiteSpace(this.Name)) AddBrokenRule(new BusinessRule() { Propery = "Name", Rule = "名称不为空" });
            if (this.Age < 18 || this.Age >= 65) AddBrokenRule(new BusinessRule() { Propery = "Age", Rule = "职工年龄必须在法定年龄之内" });
        }
    }

    public interface IEmployeeRepository : IRepository<Employee,System.Guid>
    { }
}
