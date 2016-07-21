using ERPS.Models;
using Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EPRS.Service
{
    public class MenuInfoService:IMenuInfoService
    {
        IMenuInfoRepository _menuInfoRepository = null;
        IPositionRepository _PositionRepository = null;
        IUnitOfWork _unitOfWork = null;

        public MenuInfoService(IUnitOfWork unitOfWork,
            IPositionRepository positionRepository,
            IMenuInfoRepository menuInfoRepository) {
            _unitOfWork = unitOfWork;
            _menuInfoRepository = menuInfoRepository;
            _PositionRepository = positionRepository;

            _menuInfoRepository.UnitOfWork = unitOfWork;
            _PositionRepository.UnitOfWork = unitOfWork;
        }

        public List<MenuInfoDTO> GetMenu(int id,int userId)
        {
            var position = _PositionRepository.GetAllWithNavigationalProperty("Department")
                .Where(it => it.Users.Where(u => u.Id == userId)
                    .FirstOrDefault() != null)
                    .First();
            if (id <= 0)
            {
                return _menuInfoRepository.GetAll()
                    .Where(it => it.Depth == 1 && it.IsDisplay == true)
                    .ToList()
                    .MapperTo<MenuInfo, MenuInfoDTO>()
                    .Where(it => position.PagePower.Contains(it.Id.ToString()) || position.Department.Code.Equals("1") 
                        && ( position.PagePower.Contains(it.Id.ToString()) || position.Department.Code.Equals("1")))
                    .ToList();
            }
            else
            {
                return _menuInfoRepository.GetAll()
                    .Where(it => it.Parent.Id == id && it.IsDisplay == true 
                        && (position.PagePower.Contains(it.Id.ToString()) || position.Department.Code.Equals("1")))
                    .ToList()
                    .MapperTo<MenuInfo, MenuInfoDTO>()
                    .ToList();
            }

        }
    }
}
