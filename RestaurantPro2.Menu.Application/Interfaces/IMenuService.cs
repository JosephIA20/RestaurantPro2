
using RestaurantPro2.Menu.Application.Core;
using RestaurantPro2.Menu.Application.Dtos;
using RestaurantPro2.Menu.Application.Services;
using System.Threading.Tasks;

namespace RestaurantPro2.Menu.Application.Interfaces
{
    public interface IMenuService 
    {

        ServiceResult GetMenus();

        ServiceResult GetMenu(int id);
        ServiceResult UptadeMenu(MenuUpdateDto menuUpdateModel);

        ServiceResult RemoveMenu(MenuRemoveDto menuRemoveModelcs);

        ServiceResult SaveMenu(MenuSaveDto menuSaveModel);


    }
}
