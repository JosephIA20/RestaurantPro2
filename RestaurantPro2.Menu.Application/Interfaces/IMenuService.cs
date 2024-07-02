
using RestaurantPro2.Menu.Application.Core;
using RestaurantPro2.Menu.Application.Services;
using System.Threading.Tasks;

namespace RestaurantPro2.Menu.Application.Interfaces
{
    public interface IMenuService
    {

        ServiceResult GetMenus();

        ServiceResult GetMenu(int id);
        ServiceResult UptadeMenu(MenuUpdateModel menuUpdateModel);

        ServiceResult RemoveMenu(MenuRemoveModelcs menuRemoveModelcs);

        ServiceResult SaveMenu(MenuSaveModel menuSaveModel);


    }
}
