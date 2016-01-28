using ERP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ERP.DService
{
    public static class MSRoleMapper
    {
        public static MSRole ConvertToMSRole(this MSRoleDTO msRoleDTO,List<System.Guid> rights, IMSRightRepository msRightRepository)
        {
            MSRole msRole = msRoleDTO.MapperTo<MSRoleDTO, MSRole>();
            msRole.MSRight = msRightRepository.GetAll().Where(it => rights.Contains(it.RightId)).ToList();
            return msRole;
        }
    }
}
