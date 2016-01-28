using ERP.Infrastructure;
using ERP.Models;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace ERP.Repository
{
   public class MSUserUnitOfWorkRepository:EFRepository<MSUser,System.Guid>,IMSUserRepository
    {
        public void UpdateUserRole(Guid userId, Guid roleId)
        {
            MSUser msUser = _unitOfWork.DbContext.Set<MSUser>().Include(it => it.MSRole).Where(it => it.UserId == userId).Single();
            msUser.MSRole = _unitOfWork.DbContext.Set<MSRole>().Where(it => it.RoleId == roleId).Single();
            _unitOfWork.DbContext.Entry<MSUser>(msUser).State = EntityState.Modified;
        }
    }
}
