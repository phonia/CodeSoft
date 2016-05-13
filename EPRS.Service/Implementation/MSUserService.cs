using ERPS.Infrastructure;
using ERPS.Models;
using Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EPRS.Service
{
    public class MSUserService:IMSUserService
    {
        private IMSUserRepository _msUserRepository = null;
        private IUnitOfWork _unitOfWork = null;

        public MSUserService(IMSUserRepository msUserRepository,IUnitOfWork unitOfWork)
        {
            this._msUserRepository = msUserRepository;
            this._unitOfWork = unitOfWork;

            this._msUserRepository.UnitOfWork = unitOfWork;
        }

        public bool Login(string name, string pwd)
        {
            if (_msUserRepository.GetAll().Where(it=>it.Name.Equals(name)&&it.Pwd.Equals(pwd)).SingleOrDefault()!=null)
                return true;
            else
                return false;
        }

        public bool Logout(string name)
        {
            throw new NotImplementedException();
        }

        public List<MSUserDTO> GetAllMSUser()
        {
            List<MSUser> msUsers = _msUserRepository.GetAll().ToList();
            return msUsers.MapperTo<MSUser, MSUserDTO>().ToList();
        }

        public MSUserDTO GetMSUserByName(string name)
        {
            MSUser msUser = _msUserRepository.GetByKey(name);
            if (msUser == null) throw new DomainServiceException("不存在该用户！");
            return msUser.MapperTo<MSUser, MSUserDTO>();
        }


        public void RegisterUser(MSUserDTO msUserDTO)
        {

        }
    }
}
