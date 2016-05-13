using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EPRS.Service
{
    [AttributeUsage(AttributeTargets.Method)]
    public class UserPermissionAttribute : Attribute
    {
        public MSRoleDTO MSRoleDTO { get; set; }

        public bool IsPermisson(MSUserDTO userDTO)
        {
            //IMSUserService MSUserService = (new UnityBootStrapper()).UnityContainer.Resolve<IMSUserService>();
            //if (String.IsNullOrWhiteSpace(username) || String.IsNullOrWhiteSpace(ModuleName) || String.IsNullOrWhiteSpace(OperatorName))
            //    throw new ArgumentNullException("UserPermissionAttribute属性不能为空!");
            //if (MSUserService == null) new DomainServiceException("MSUserService不能为空！");
            //if (MSUserService.IsPermisson(username, ModuleName, OperatorName))
            //    return true;
            return true;
        }
    }
}
