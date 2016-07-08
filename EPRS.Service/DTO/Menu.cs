using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EPRS.Service
{
    /// <summary>
    /// 菜单 传输类
    /// </summary>
    public class MenuInfoDTO
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public String Url { get; set; }
        public bool IsMenu { get; set; }

        public List<MenuInfoDTO> MenuInfoDTOs { get; set; }
    }
}
