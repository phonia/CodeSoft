using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ERPS.Models;
using Infrastructure;

namespace EPRS.Service
{
    public class UserService:IUserService
    {
        ISUserRepository _userRepository = null;
        IPositionRepository _positionRepository = null;
        IDepartmentRepository _departmentRepository = null;
        IActionPermissionRepository _actionPermissionRepository = null;
        IUnitOfWork _unitOfWork = null;
        private static object _lockObject = new object();

        public UserService(ISUserRepository userRepository,IPositionRepository positonRepository,IActionPermissionRepository actionPermissionRepository,
            IDepartmentRepository departmentRepository,IUnitOfWork unitOfWork )
        {
            this._userRepository = userRepository;
            this._positionRepository = positonRepository;
            this._departmentRepository = departmentRepository;
            this._actionPermissionRepository = actionPermissionRepository;
            this._unitOfWork = unitOfWork;

            this._userRepository.UnitOfWork = unitOfWork;
            this._positionRepository.UnitOfWork = unitOfWork;
            this._departmentRepository.UnitOfWork = unitOfWork;
            this._actionPermissionRepository.UnitOfWork = unitOfWork;
        }

        public List<SUserDTO> GetUsers()
        {
            return this._userRepository.GetAllWithNavigationalProperty("Position", "Position.Department")
                .Where(it=>!it.Position.Department.Code.Equals("1"))
                .ConvertToUserDTO()
                .ToList();
        }

        public SUserDTO GetUserByName(string name)
        {
            return this._userRepository.GetAllWithNavigationalProperty("Position", "Position.Department")
                .Where(it => it.LoginName.Equals(name))
                .First()
                .ConvertToUserDTO();
        }

        public SUserDTO GetUserByKey(int id)
        {
            return this._userRepository.GetAllWithNavigationalProperty("Position", "Position.Department")
                .Where(it =>it.Id==id)
                .First()
                .ConvertToUserDTO();
        }

        public List<DepartmentDTO> GetDepartments()
        {
            return this._departmentRepository.GetAll().Where(it=>!it.Code.Equals("1"))
                .MapperTo<Department, DepartmentDTO>()
                .ToList();
        }

        public DepartmentDTO GetDepartmentByKey(int id)
        {
            return this._departmentRepository.GetByKey(id)
                .MapperTo<Department, DepartmentDTO>();
        }

        public DepartmentDTO GetDepartmentByName(string name)
        {
            return this._departmentRepository.GetAll().Where(it=>it.Name.Equals(name))
                .MapperTo<Department, DepartmentDTO>()
                .First();
        }

        public List<PositionDTO> GetPositions()
        {
            return this._positionRepository.GetAllWithNavigationalProperty("Department")
                .Where(it=>!it.Department.Code.Equals("1"))
                .ConverToPositionDTO()
                .ToList();
        }

        public PositionDTO GetPositionByKey(int id)
        {
            return this._positionRepository.GetAllWithNavigationalProperty("Department")
                .Where(it => it.Id == id)
                .First()
                .ConverToPositionDTO();
        }

        public PositionDTO GetPositionByName(string name)
        {
            return this._positionRepository.GetAllWithNavigationalProperty("Department")
                .Where(it => it.Name.Equals(name))
                .First()
                .ConverToPositionDTO();
        }

        public List<ActionPermissionDTO> GetActionPersionsByMenuId(int id)
        {
            return _actionPermissionRepository.GetAll().Where(it=>it.MenuInfo.Id==id).MapperTo<ActionPermission,ActionPermissionDTO>().ToList();
        }

        public SUserDTO RegisterUser(SUserDTO userDTO)
        {
            SUser user = userDTO.MapperTo<SUserDTO, SUser>();
            //不仅仅是验证数据的完整性，也包括数据的合法性
            user.Position = _positionRepository.GetByKey(userDTO.PositionId);
            _userRepository.Add(user);
            _unitOfWork.Commit();
            return GetUserByName(userDTO.LoginName);
        }

        public PositionDTO RegisterPosition(PositionDTO positionDTO)
        {
            Position position = positionDTO.MapperTo<PositionDTO, Position>();
            //验证
            position.Department = _departmentRepository.GetByKey(positionDTO.DepartmentId);
            _positionRepository.Add(position);
            _unitOfWork.Commit();
            return GetPositionByName(positionDTO.Name);
        }

        public DepartmentDTO RegisterDepartment(DepartmentDTO departmentDTO,String parentCode)
        {
            Department department = departmentDTO.MapperTo<DepartmentDTO, Department>();
            lock (_lockObject)
            {
                //var sumCode = _departmentRepository.GetAll().Where(it => it.Code.Length >= 3).Select(it => new { code = it.Code.Substring(0, 3) }).Distinct();
                //department.Code = parentCode + GenerateCode(sumCode.Count());
                var sumCode = _departmentRepository.GetAll().Where(it => it.Code.Length >= 3).Select(it => new
                {
                    code = it.Code.Substring(parentCode.Length % 3 == 0 ? parentCode.Length : parentCode.Length - parentCode.Length % 3, 3)
                }).Distinct();
                department.Code = parentCode + GenerateCode(sumCode.Count());
                department.Sort = 0;
                department.Depth = (parentCode.Length - (parentCode.Length % 3)) / 3 + 1;
                department.UpdateDate = DateTime.Now;
                //
                _departmentRepository.Add(department);
                _unitOfWork.Commit();
            }
            return GetDepartmentByName(departmentDTO.Name);
        }

        String GenerateCode(Int32 code)
        {
            if (code < 0) return "";
            if (code < 9) return "00" + code;
            if (code < 99) return "0" + code;
            return code.ToString();
        }

        public SUserDTO UpdateUser(SUserDTO userDTO)
        {
            throw new NotImplementedException();
        }

        public PositionDTO UpdatePosition(PositionDTO positionDTO)
        {
            throw new NotImplementedException();
        }

        public DepartmentDTO UpdateDepartment(DepartmentDTO departmentDTO)
        {
            throw new NotImplementedException();
        }

        public bool RemoveUser(int id)
        {
            _userRepository.RemoveNonCascaded(id);
            _unitOfWork.Commit();
            return true;
        }

        public bool RemoveUser(List<int> users)
        {
            foreach (var node in users)
            {
                _userRepository.RemoveNonCascaded(node);
            }
            _unitOfWork.Commit();
            return true;
        }

        public bool RemovePosition(int id)
        {
            _positionRepository.RemoveNonCascaded(id);
            _unitOfWork.Commit();
            return true;
        }

        public bool RemovePosition(List<int> positions)
        {
            foreach (var node in positions)
            {
                _positionRepository.RemoveNonCascaded(node);
            }
            _unitOfWork.Commit();
            return true;
        }

        public bool RemoveDepartment(int id)
        {
            _departmentRepository.RemoveNonCascaded(id);
            _unitOfWork.Commit();
            return true;
        }

        public bool RemoveDepartment(List<int> departments)
        {
            foreach (var node in departments)
            {
                _departmentRepository.RemoveNonCascaded(node);
            }
            _unitOfWork.Commit();
            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="loginName"></param>
        /// <param name="loginPwd"></param>
        /// <returns>return null if Login Failed</returns>
        public SUserDTO Login(string loginName, string loginPwd)
        {
            return this._userRepository.GetAllWithNavigationalProperty("Position", "Position.Department")
                .Where(it => it.LoginName.Equals(loginName) && it.LoginPass.Equals(loginPwd))
                .FirstOrDefault()
                .ConvertToUserDTO();
        }

        public bool Logout(string loginName)
        {
            throw new NotImplementedException();
        }

        public bool Authority(SUserDTO user, String url)
        {
            SUser suser = user.MapperTo<SUserDTO, SUser>();
            suser.Position = _positionRepository.GetAll().Where(it => it.Id == user.PositionId).First();
            ActionPermission ap = _actionPermissionRepository.GetAll().Where(it => it.Url.Equals(url)).First();
            if (suser.Position.ControlPower.Split(',').ToList().Contains(ap.Id.ToString()))
                return true;
            else
                return false;
        }
    }
}
