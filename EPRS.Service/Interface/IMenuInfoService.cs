﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EPRS.Service
{
    public interface IMenuInfoService
    {
        List<MenuInfoDTO> GetMenu(int id,int userId);
    }
}
