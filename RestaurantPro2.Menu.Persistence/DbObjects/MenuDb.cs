using RestauranteMaMonolitica.Web.Data.Entities;
using RestauranteMaMonolitica.Web.Data.Interfaces;
using RestauranteMaMonolitica.Web.Data.Models;
using RestauranteMaMonolitica.Web.Data.Repositores;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RestauranteMaMonolitica.Web.Data.DbObjects
{
    public class MenuDb :IMenuRepositories
    {
        private readonly MenuRepositories _menuRepositories;

        public MenuDb(MenuRepositories menuRepositories)
        {
            _menuRepositories = menuRepositories;
        }

        public List<MenuGetModel> GetMenus()
        {
            return _menuRepositories.GetMenus();
        }

        public void Save(MenuSaveModel menuSaveModel)
        {
            _menuRepositories.Save(menuSaveModel);
        }

        public void Remove(MenuRemoveModelcs menuRemoveModel)
        {
            _menuRepositories.Remove(menuRemoveModel);
        }

        public void Uptade(MenuUpdateModel menuUpdate)
        {
            _menuRepositories.Uptade(menuUpdate);
        }
        public MenuGetModel GetMenu(int idMenu)
        {
            return  _menuRepositories.GetMenu(idMenu);
        }
    }
}
