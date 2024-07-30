using Microsoft.Extensions.Logging;
using RestaurantPro2.menu.Domain.interfaces;
using RestaurantPro2.menu.Persistence.Context;
using System.Linq.Expressions;
using RestaurantPro2.menu.Domain.Entities;
using RestauranteMaMonolitica.Web.Data.Exceptions;


namespace RestaurantPro2.menu.Persistence.Repositores
{
    public class MenuRepositories : IMenuRepository
    {
        private readonly RestauranteContext _context;
        private ILogger<MenuRepositories>  _logger;


        public MenuRepositories(RestauranteContext context, ILogger<MenuRepositories> _logger)
        {
            this._context = context;
           this._logger = _logger;
        }

        public bool Exists(Expression<Func<Domain.Entities.Menu, bool>> filter)
        {
            return this._context.Menu.Any(filter);
        }

        public List<Domain.Entities.Menu> GetALL()
        {
            return this._context.Menu.ToList();
        }

        public Domain.Entities.Menu GetEntityBy(int IdPlato)
        {
            Domain.Entities.Menu? menu = null;
            try
            { 

                menu = this._context.Menu.Find(IdPlato);
                if(menu is null)
                {
                    throw new MenuDbException("El curso no se encuentra registrado.");
                }

                return menu;
            }
            catch(Exception ex)
            {
                this._logger.LogError("Error tomando los menu", ex.ToString());
            }
            return menu;
        }

        public List<Domain.Entities.Menu> GetMenus(int menuId)
        {
            throw new NotImplementedException();
        }

        public void Remove(Domain.Entities.Menu entity)
        {
            try
            {

                Domain.Entities.Menu? MenuRemove = this._context.Menu.Find(entity.IdPlato);
                if (entity is null)
                    throw new ArgumentNullException("La entidad menu no puede ser nulo");
                MenuRemove.delete_user = entity.delete_user;
                MenuRemove.delete_date = entity.delete_date;
                MenuRemove.deleted = entity.deleted;

                _context.Menu.Update(MenuRemove);
                this._context.SaveChanges();
            }
            catch(Exception ex)
            {
                this._logger.LogError("Error eliminando un menu", ex.ToString());
            }
        }

        public void Save(Domain.Entities.Menu entity)
        {
            try
            {
                if(entity is null)
                {
                    throw new ArgumentNullException("La entidad Menu no puede nulo.");
                }
                if (Exists(co => co.IdPlato.Equals(entity.IdPlato)));
                throw new MenuDbException("El Menu se encuentra registrado.");

                _context.Menu.Add(entity);
                _context.SaveChanges();
            }
            catch(Exception ex)
            {
                this._logger.LogError("Error guardando un Menu", ex.ToString());
            }
        }

        public void Uptade(Domain.Entities.Menu entity)
        {
            try
            {
                if (entity is null)
                    throw new ArgumentNullException("La entidad menu no puede nulo.");


                Domain.Entities.Menu? menu = this._context.Menu.Find(entity.IdPlato);

                if (menu is null)
                    throw new MenuDbException("El menu que desea actualizar no se encuentra registrado.");

                menu.Descripcion = entity.Descripcion;
                menu.Categoria = entity.Categoria;
                menu.Nombre = entity.Nombre;
                menu.modify_date = entity.modify_date;
                menu.modify_user = entity.modify_user;

                _context.Menu.Update(menu);
                _context.SaveChanges();

            }
            catch (Exception ex)
            {

                this._logger.LogError("Error actualizando el menu.", ex.ToString());
            }
        }

      
    }
}
