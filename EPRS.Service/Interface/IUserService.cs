using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EPRS.Service
{
    public interface IUserService
    {
        List<SUserDTO> GetUsers();
        SUserDTO GetUserByName(String name);
        SUserDTO GetUserByKey(int id);
        List<DepartmentDTO> GetDepartments();
        DepartmentDTO GetDepartmentByKey(int id);
        DepartmentDTO GetDepartmentByName(String name);
        List<PositionDTO> GetPositions();
        PositionDTO GetPositionByKey(int id);
        PositionDTO GetPositionByName(String name);
        List<ActionPermissionDTO> GetActionPersionsByMenuId(int id);

        SUserDTO RegisterUser(SUserDTO userDTO);
        PositionDTO RegisterPosition(PositionDTO positionDTO);
        DepartmentDTO RegisterDepartment(DepartmentDTO departmentDTO,String parentCode);

        SUserDTO UpdateUser(SUserDTO userDTO);
        PositionDTO UpdatePosition(PositionDTO positionDTO);
        DepartmentDTO UpdateDepartment(DepartmentDTO departmentDTO);

        bool RemoveUser(int id);
        bool RemoveUser(List<int> users);
        bool RemovePosition(int id);
        bool RemovePosition(List<int> positions);
        bool RemoveDepartment(int id);
        bool RemoveDepartment(List<int> departments);

        SUserDTO Login(String loginName, String loginPwd);

        bool Logout(String loginName);
        bool Authority(SUserDTO user, String url);
    }
}
