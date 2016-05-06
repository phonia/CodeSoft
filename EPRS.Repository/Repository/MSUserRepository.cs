using ERPS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EPRS.Repository
{
    public class MSUserRepository:EFRepository<MSUser,String>,IMSUserRepository
    {
    }
}
