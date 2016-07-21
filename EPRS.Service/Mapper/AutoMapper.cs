

/***********************************************
 * auto-generated code from T4
 * 
 * ********************************************/

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
            Mapper.CreateMap<WebConfig, WebConfigDTO>();
			Mapper.CreateMap<WebConfigDTO, WebConfig>();
            Mapper.CreateMap<MenuInfo, MenuInfoDTO>();
			Mapper.CreateMap<MenuInfoDTO, MenuInfo>();
            Mapper.CreateMap<ActionPermission, ActionPermissionDTO>();
			Mapper.CreateMap<ActionPermissionDTO, ActionPermission>();
            Mapper.CreateMap<SUser, SUserDTO>();
			Mapper.CreateMap<SUserDTO, SUser>();
            Mapper.CreateMap<PersonInfo, PersonInfoDTO>();
			Mapper.CreateMap<PersonInfoDTO, PersonInfo>();
            Mapper.CreateMap<OnLineInfo, OnLineInfoDTO>();
			Mapper.CreateMap<OnLineInfoDTO, OnLineInfo>();
            Mapper.CreateMap<Department, DepartmentDTO>();
			Mapper.CreateMap<DepartmentDTO, Department>();
            Mapper.CreateMap<Position, PositionDTO>();
			Mapper.CreateMap<PositionDTO, Position>();
            Mapper.CreateMap<UserLog, UserLogDTO>();
			Mapper.CreateMap<UserLogDTO, UserLog>();
            Mapper.CreateMap<ErrorLog, ErrorLogDTO>();
			Mapper.CreateMap<ErrorLogDTO, ErrorLog>();
            Mapper.CreateMap<Sex, SexDTO>();
			Mapper.CreateMap<SexDTO, Sex>();
            Mapper.CreateMap<Education, EducationDTO>();
			Mapper.CreateMap<EducationDTO, Education>();
            Mapper.CreateMap<ActionSign, ActionSignDTO>();
			Mapper.CreateMap<ActionSignDTO, ActionSign>();
        }
    }
}
