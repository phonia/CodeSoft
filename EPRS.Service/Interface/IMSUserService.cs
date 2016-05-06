using ERPS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EPRS.Service
{
    public interface IMSUserService
    {
        bool Login(String name, String pwd);
        bool Logout(String name);
        List<MSUserDTO> GetAllMSUser();
        MSUserDTO GetMSUserByName(String name);
    }
}
