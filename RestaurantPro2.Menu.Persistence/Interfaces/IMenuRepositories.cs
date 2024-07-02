using RestauranteMaMonolitica.Web.Data.Models;

namespace RestauranteMaMonolitica.Web.Data.Interfaces
{
    public interface IMenuRepositories
    {
        void Save(MenuSaveModel menuSave);
        void Uptade(MenuUpdateModel menuUpdate);
        void Remove(MenuRemoveModelcs menuRemoveModel);
        List<MenuGetModel> GetMenus();
       public MenuGetModel GetMenu(int idMenu);
        void Save(MenuSaveModel menuSave);
    }
}
