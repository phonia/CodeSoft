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
        IUnitOfWork _unitOfWork = null;

        public MenuInfoService(IUnitOfWork unitOfWork,IMenuInfoRepository menuInfoRepository) {
            _unitOfWork = unitOfWork;
            _menuInfoRepository = menuInfoRepository;

            _menuInfoRepository.UnitOfWork = unitOfWork;
        }

        public List<MenuInfoDTO> GetMenu(int id)
        {
            if (id <= 0)
            {
                return _menuInfoRepository.GetAll()
                    .Where(it => it.Depth == 1 && it.IsDisplay == true)
                    .ToList()
                    .MapperTo<MenuInfo, MenuInfoDTO>().ToList();
            }
            else
            {
                return _menuInfoRepository.GetAll()
                    .Where(it => it.Parent.Id == id && it.IsDisplay == true )
                    .MapperTo<MenuInfo, MenuInfoDTO>().ToList();
            }

        }
    }
}
