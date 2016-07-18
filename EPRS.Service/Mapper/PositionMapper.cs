using ERPS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EPRS.Service
{
    public static class PositionMapper
    {
        public static IEnumerable<PositionDTO> ConverToPositionDTO(this IEnumerable<Position> positions)
        {
            List<PositionDTO> list = new List<PositionDTO>();
            if (positions != null)
            {
                foreach (var node in positions)
                {
                    list.Add(node.ConverToPositionDTO());
                }
            }
            return list;
        }

        public static PositionDTO ConverToPositionDTO(this Position position)
        {
            if (position == null) return null;
            PositionDTO dto = position.MapperTo<Position, PositionDTO>();
            if (position.Department != null)
            {
                dto.DepartmentId = position.Department.Id;
                dto.DepartmentName = position.Department.Name;
            }
            return dto;
        }
    }
}
