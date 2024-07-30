using RestaurantPro2.menu.Application.Core;
using RestaurantPro2.menu.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantPro2.menu.Application.Contracts
{
   public interface IMenuService
    {
        ServiceResult GetMenu();
        ServiceResult GetMenuById(int IdPlato);
        ServiceResult UptadeMenu(MenuUpdateDto menuUpdateDto);
        ServiceResult SaveMenu(MenuSaveDto menuSaveDto);
        ServiceResult MenuRemove(MenuRemoveDto menuRemoveDto);
    }
}
