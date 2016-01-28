using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ERP.Infrastructure;

namespace ERP.Models
{
    public partial class MSUser:EntityBase,IAggregateRoot
    {
        protected override void Validate()
        {
            if (String.IsNullOrWhiteSpace(this.UserName)) this.AddBrokenRule(new BusinessRule() { Propery = "UserName", Rule = "用户名不为空" });
            if (String.IsNullOrWhiteSpace(this.Password)) this.AddBrokenRule(new BusinessRule() { Propery="Password",Rule="密码不为空"});
        }

        public void Register()
        { }
    }

    public interface IMSUserRepository : IRepository<MSUser,System.Guid>
    {
        //void UpdateUserRole(System.Guid userId, System.Guid roleId);
    }
}
