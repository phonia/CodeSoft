using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EPRS.Service
{
    public interface IUserService
    {
        List<UserDTO> GetUsers();
        UserDTO GetUserByName();
        UserDTO GetUserByKey();
        void GetDepartments();
        void GetDepartmentByKey();
        void GetDepartmentByName();
        void GetPositions();
        void GetPositionByKey();
        void GetPositionByName();

        void RegisterUser();
        void RegisterPosition();
        void RegisterDepartment();

        UserDTO UpdateUser();
        void UpdatePosition();
        void UpdateDepartment();

        bool RemoveUser();
        bool RemovePosition();
        bool RemoveDepartment();

        UserDTO Login(String loginName, String loginPwd);
    }
}
