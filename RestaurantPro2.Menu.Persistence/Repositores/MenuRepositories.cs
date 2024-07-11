
using RestauranteMaMonolitica.Web.Data.Interfaces;
using RestaurantPro2.Menu.Application.Dtos;
using RestaurantPro2.Menu.Domain.Entities;
using RestaurantPro2.Menu.Persistence.Context;

namespace RestauranteMaMonolitica.Web.Data.Repositores
{
    public class MenuRepositories : IMenuRepositories
    {
        private readonly RestauranteContext context;

        public MenuRepositories(RestauranteContext context)
        {
            this.context = context;
        }

        public void Save(MenuSaveDto menuSave)
        {
            Menu menu = new Menu()
            {
                IdPlato = menuSave.IdPlato,
                Categoria = menuSave.Categoria,
                Descripcion = menuSave.Descripcion,
                Nombre = menuSave.Nombre,
                Precio = (decimal)menuSave.Precio,
                creation_user = menuSave.creation_user,
                creation_date =menuSave.creation_date,
            };
            this.context.Menu.Add(menu);
            this.context.SaveChanges();
        }

        public void Uptade(MenuUpdateDto menuUpdate)
        {
            if (menuUpdate is null)
            {
                throw new MenuDbException("El menu tubo un error al actualizar");

            }
            Menu menu = this.context.Menu.Find(menuUpdate.IdPlato);
            menu.modify_date = menuUpdate.ModifyDate;
            menu.Nombre = menuUpdate.Nombre;
            menu.Descripcion = menuUpdate.Descripcion;
            menu.Precio = (decimal)menuUpdate.Precio;
            menu.Categoria = menuUpdate.Categoria;
            menu.modify_user = menuUpdate.ModifyUser;

            this.context.Update(menu);
            this.context.SaveChanges();
        }

        public void Remove(MenuRemoveDto menuRemoveModel)
        {
            Menu menuDelete = this.context.Menu.Find(menuRemoveModel.IdPlato);
            {
                if (menuDelete is null)
                {
                    throw new MenuDbException("El menu tubo un error al elimar un dato");
                }
                menuDelete.deleted = menuRemoveModel.deleted;
                menuDelete.delete_date = menuRemoveModel.deleted_date;
                menuDelete.delete_user = menuRemoveModel.deleted_user;

                this.context.Menu.Update(menuDelete);
                this.context.SaveChanges();
            }
        }

        public List<MenuGetModel> GetMenus()
        {
            return this.context.Menu.Select(Menus => new MenuGetModel()
            {

                IdPlato = Menus.IdPlato,
                Categoria = Menus.Categoria,
                Descripcion = Menus.Descripcion,
                Nombre = Menus.Nombre,
                Precio = Menus.Precio,
            }).ToList();
        }
        public MenuGetModel GetMenu(int idMenu)
        {
            var menu = this.context.Menu.Find(idMenu);

            if (menu == null)
            {
                throw new MenuDbException("Menu not found");
            }

            return new MenuGetModel()
            {
                IdPlato = menu.IdPlato,
                Categoria = menu.Categoria,
                Descripcion = menu.Descripcion,
                Nombre = menu.Nombre,
                Precio = menu.Precio,
            };



        }
    }
}
