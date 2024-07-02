
using RestaurantPro2.Common.Data.Repository;

namespace RestaurantPro2.Menu.Domain.interfaces
{
    public interface IMenuRepository : IBaseRepository<Menu.Domain.Entities.Menu,int>
    {

        List<Menu.Domain.Entities.Menu> GetMenus(int menuId);
    }

  }

