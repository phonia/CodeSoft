using ERP.Infrastructure;
using ERP.Models;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ERP.Repository
{
    public class MSRoleUnitOfWorkRepository:EFRepository<MSRole,System.Guid>,IMSRoleRepository
    {

    }
}
