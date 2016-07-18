using ERPS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EPRS.Service
{
    public static class UserMapper
    {
        public static IEnumerable<SUserDTO> ConvertToUserDTO(this IEnumerable<SUser> users)
        {
            List<SUserDTO> list = new List<SUserDTO>();
            if (users != null)
            {
                foreach (var node in users)
                {
                    list.Add(node.ConvertToUserDTO());
                }
            }
            return list;
        }

        public static SUserDTO ConvertToUserDTO(this SUser user)
        {
            if (user == null) return null;
            SUserDTO dto = user.MapperTo<SUser, SUserDTO>();
            if (user.Position != null)
            {
                dto.PositionId = user.Position.Id;
                dto.PositionName = user.Position.Name;
                if (user.Position.Department != null)
                {
                    dto.DepartmentId = user.Position.Department.Id;
                    dto.DepartmentName = user.Position.Department.Name;
                }
            }
            return dto;
        }
    }
}
