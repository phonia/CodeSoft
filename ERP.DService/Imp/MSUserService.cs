using ERP.Infrastructure;
using ERP.Models;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ERP.DService
{
    public class MSUserService
    {
        private IMSUserRepository _msUserRepository = null;
        private IMSRoleRepository _msRoleRepository = null;
        private IUnitOfWork _unitOfWork = null;
        private IMSRightRepository _msRightRepository = null;
        private IMSModuleRepository _msModuleRepository = null;
        private IMSDomainRepository _msDomainRepository = null;

        [InjectionConstructor]
        public MSUserService(IUnitOfWork unitOfWork,
            IMSUserRepository msUserRepository, IMSRoleRepository msRoleRepository,IMSRightRepository msRightRepository,
            IMSModuleRepository msModuleRepository,IMSDomainRepository msDomainRepository)
        {
            this._msRoleRepository = msRoleRepository;
            this._msUserRepository = msUserRepository;
            this._msRightRepository = msRightRepository;
            this._msDomainRepository = msDomainRepository;
            this._msModuleRepository = msModuleRepository;

            this._unitOfWork = unitOfWork;
            this._msUserRepository.UnitOfWork = unitOfWork;
            this._msRoleRepository.UnitOfWork = unitOfWork;
            this._msRightRepository.UnitOfWork = unitOfWork;
            this._msDomainRepository.UnitOfWork = unitOfWork;
            this._msModuleRepository.UnitOfWork = unitOfWork;
            
        }

        public virtual void RegisterMSUser([NotNull]MSUserDTO msUserDTO)
        {
            msUserDTO.UserId = System.Guid.NewGuid();
            MSUser msUser = msUserDTO.ConverToMSUser(_msRoleRepository);
            if (_msUserRepository.GetAll().Where(it => it.UserName.Equals(msUserDTO.UserName)).FirstOrDefault() != null)
                throw new DomainException("用户名已存在!");
            _msUserRepository.Add(msUser);
            _unitOfWork.Commit();
        }

        public virtual void UpdateMSUserRole([NotNull]System.Guid UserId, [NotNull]System.Guid RoleId)
        {
            MSUser msUser = _msUserRepository.GetAll().Where(it => it.UserId == UserId).Single();
            msUser.MSRole = _msRoleRepository.GetAll().Where(it => it.RoleId == RoleId).Single();
            _msUserRepository.Save(msUser);
            _unitOfWork.Commit();
        }

        public virtual void RemoveMSUser([NotNull]System.Guid userId)
        {
            MSUser msUser = _msUserRepository.GetAll().Where(it => it.UserId == userId).Single();
            _msUserRepository.Remove(msUser);
            _unitOfWork.Commit();
        }

        public virtual void RemoveMSUsers([NotNull]List<System.Guid> list)
        {
            List<MSUser> msUserList = _msUserRepository.GetAll()
                .Where(it=>list.Contains(it.UserId)).ToList();
            foreach (var item in msUserList)
            {
                _msUserRepository.Remove(item);
            }
            _unitOfWork.Commit();
        }

        public virtual List<MSUserDTO> GetAllMSUser()
        {
            var list = _msUserRepository.GetAll()
                .Select(it => new
                {
                    UserId = it.UserId,
                    UserName = it.UserName,
                    Password = it.Password,
                    MSRole = it.MSRole
                }
                ).ToList();
            List<MSUser> msUserList = list
                .Select(it => new MSUser
                {
                    MSRole = it.MSRole,
                    UserId = it.UserId,
                    UserName = it.UserName,
                    Password = it.Password
                }).ToList();
            return msUserList.MapperTo<MSUser, MSUserDTO>().ToList();

            //List<MSUserDTO> msUserDTOList = _msUserRepository.GetAll().Select(it => new MSUserDTO
            //{
            //    Passworld = it.Password,
            //    RoleName = it.MSRole.RoleName,
            //    UserId = it.UserId,
            //    UserName = it.UserName
            //}).ToList();
            //return msUserDTOList;
        }

        public virtual MSUserDTO GetMSUser(System.Guid userId)
        {
            var list = _msUserRepository.GetAll()
                .Where(it=>it.UserId==userId)
                .Select(it => new
                {
                    UserId = it.UserId,
                    UserName = it.UserName,
                    Password = it.Password,
                    MSRole = it.MSRole
                }
                ).ToList();
            MSUser msUser = list
                .Select(it => new MSUser()
                {
                    MSRole = it.MSRole,
                    UserId = it.UserId,
                    UserName = it.UserName,
                    Password = it.Password
                }).Single();
            return msUser.MapperTo<MSUser, MSUserDTO>();
        }

        public virtual bool Login(string userName, string userPwd)
        {
            var list = _msUserRepository.GetAll().Where(it => it.UserName == userName && it.Password == userPwd).ToList();
            if (list != null && list.Count > 0) return true;
            return false;
        }

        public virtual void RegiseterRole(MSRoleDTO msRoleDTO,List<System.Guid> rights)
        {
            msRoleDTO.RoleId = System.Guid.NewGuid();
            MSRole msRole = msRoleDTO.ConvertToMSRole(rights,_msRightRepository);
            if (_msRoleRepository.GetAll().Where(it => it.RoleName.Equals(msRoleDTO.RoleName)).FirstOrDefault() != null)
                throw new DomainException("已存在的角色名");
            _msRoleRepository.Add(msRole);
            _unitOfWork.Commit();
        }

        /*
         * 修改角色权限 是否会改变 权限-角色表中的数据会如何变化 需要验证
         * **/
        public virtual void UpdateMSRoleRight(System.Guid roleId,List<System.Guid> rights)
        {
            MSRole msRole = _msRoleRepository.GetAll().Where(it => it.RoleId == roleId).Single();
            msRole.MSRight = _msRightRepository.GetAll().Where(it => rights.Contains(it.RightId)).ToList();
            _msRoleRepository.Save(msRole);
            _unitOfWork.Commit();
        }

        public virtual void RemvoeMSRole(System.Guid roleId)
        {
            MSRole msRole = _msRoleRepository.GetAll().Where(it => it.RoleId == roleId).Single();
            _msRoleRepository.Remove(msRole);
            _unitOfWork.Commit();
        }

        public void RemoveMSRoles()
        { }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="roleId"></param>
        /// <returns></returns>
        public List<MSRightDTO> GetMSRoleRight(System.Guid roleId)
        {
            var list = _msRoleRepository.GetAll().Where(it => it.RoleId == roleId).Single().MSRight.Select(it => new { 
                MSFunc=it.MSFunc,
                MSModule=it.MSModule,
                RightId=it.RightId
            });
            List<MSRight> msRight = list.Select(it => new MSRight() { 
                MSFunc=it.MSFunc,
                MSModule=it.MSModule,
                RightId=it.RightId
            }).ToList();
            return msRight.MapperTo<MSRight, MSRightDTO>().ToList();
        }

        public virtual List<MSRoleDTO> GetAllMSRoles()
        {
            var msRoleList = _msRoleRepository.GetAll();
            return msRoleList.MapperTo<MSRole, MSRoleDTO>().ToList();
        }

        public List<MSRightDTO> GetAllRights()
        {
            var list = _msRightRepository.GetAll().Select(it => new
            {
                MSFunc = it.MSFunc,
                MSModule = it.MSModule,
                RightId = it.RightId
            }).ToList();
            List<MSRight> msRight = list.Select(it => new MSRight()
            {
                MSFunc = it.MSFunc,
                MSModule = it.MSModule,
                RightId = it.RightId
            }).ToList();
            return msRight.MapperTo<MSRight, MSRightDTO>().ToList();
        }

        public List<MSRightDTO> GetRightsOfModule(string moduleId)
        {
            var list = _msRightRepository.GetAll().Where(it=>it.MSModule!=null&&it.MSModule.ModuleId==moduleId).Select(it => new
            {
                MSFunc = it.MSFunc,
                MSModule = it.MSModule,
                RightId = it.RightId
            }).ToList();
            List<MSRight> msRight = list.Select(it => new MSRight()
            {
                MSFunc = it.MSFunc,
                MSModule = it.MSModule,
                RightId = it.RightId
            }).ToList();
            return msRight.MapperTo<MSRight, MSRightDTO>().ToList();
        }

        public List<MSDomainDTO> GetAllDomain()
        {
            return _msDomainRepository.GetAll().ToList().MapperTo<MSDomain, MSDomainDTO>().ToList();
        }

        public List<MSModuleDTO> GetAllModule()
        {
            return _msModuleRepository.GetAll().MapperTo<MSModule, MSModuleDTO>().ToList();
        }

        public List<MSModuleDTO> GetModuleOfDomain(String domainId)
        {
            return _msModuleRepository.GetAll().Where(it =>it.MSDomain!=null&& it.MSDomain.DomainId == domainId).ToList().MapperTo<MSModule, MSModuleDTO>().ToList();
        }
    }
}
