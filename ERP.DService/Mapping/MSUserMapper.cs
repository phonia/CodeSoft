using ERP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ERP.DService
{
    public static class MSUserMapper
    {
        public static MSUser ConverToMSUser(this MSUserDTO msUserDTO,IMSRoleRepository msRoleRepository)
        {
            MSUser msUser = msUserDTO.MapperTo<MSUserDTO, MSUser>();
            msUser.MSRole = msRoleRepository.GetAll().Where(it => it.RoleName == msUserDTO.RoleName).Single();
            return msUser;
        }
    }
}
