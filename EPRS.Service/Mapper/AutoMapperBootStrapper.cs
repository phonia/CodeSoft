using AutoMapper;
using ERPS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EPRS.Service
{
    public class AutoMapperBootStrapper
    {
        public static void Start()
        {
            Mapper.CreateMap<MenuInfo, MenuInfoDTO>();
        }
    }
}
