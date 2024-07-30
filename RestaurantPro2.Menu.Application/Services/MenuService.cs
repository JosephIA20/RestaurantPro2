using Microsoft.Extensions.Logging;
using RestaurantPro2.menu.Application.Contracts;
using RestaurantPro2.menu.Application.Core;
using RestaurantPro2.menu.Application.Dtos;
using RestaurantPro2.menu.Domain.Entities;
using RestaurantPro2.menu.Domain.interfaces;
using RestaurantPro2.Menu.Application.Validaciones;


namespace RestaurantPro2.menu.Application.Services
{

    public class MenuService : Contracts.IMenuService
    {
        private readonly IMenuRepository _menuRepository;
        private readonly ILogger _logger;

        public MenuService(IMenuRepository _menuRepository, ILogger _logger)
        {
            this._menuRepository = _menuRepository;
            this._logger = _logger;
        }
        public Core.ServiceResult GetMenu()
        {
            ServiceResult result = new ServiceResult();
            try
            {
                var menus = this._menuRepository.GetALL();


                result.Data = (from menu in _menuRepository.GetALL()
                               where menu.deleted == false
                               select new MenuGetDto()
                               {
                                   IdPlato = menu.IdPlato,
                                   Categoria = menu.Categoria,
                                   Descripcion = menu.Descripcion,
                                   Nombre = menu.Nombre,
                                   Precio=menu.Precio,
                               }).OrderByDescending(cd =>cd.ModifyDate).ToList();               
            }
            catch(Exception ex)
            {
                result.Success = false;
                result.Message = "Error obteniendo los menus";
                this._logger.LogError(message: result.Message, ex);
            }
            return result;
        } 

        public Core.ServiceResult GetMenuById(int IdPlato)
        {
            ServiceResult result = new ServiceResult();
            try
            {
                result.Data = (from Menu in _menuRepository.GetALL()
                               where Menu.IdPlato == IdPlato

                               select new MenuGetDto()
                               {
                                   IdPlato = Menu.IdPlato,
                                   Categoria = Menu.Categoria,
                                   Descripcion = Menu.Descripcion,
                                   Nombre = Menu.Nombre,
                                   Precio = Menu.Precio,
                               }).FirstOrDefault();
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Hubo un error obtiendo los menus";
                this._logger.LogError(message: result.Message, ex.ToString());

            }
            return result;
        }

        public Core.ServiceResult MenuRemove(MenuRemoveDto menuRemoveDto)
        {
            ServiceResult result = new ServiceResult();

            try
            {
                if (menuRemoveDto is null)
                {
                    result.Success = false;
                    result.Message = $"El objeto{nameof(menuRemoveDto)} es requerido.";
                    return result;
                }


              Domain.Entities.Menu menu = new Domain.Entities.Menu();
                {
                    menu.IdPlato = (int)menuRemoveDto.IdPlato;
                    menu.deleted = menuRemoveDto.deleted;
                    menu.delete_date = menuRemoveDto.deleted_date;
                    menu.delete_user = menuRemoveDto.deleted_user;
                };

                this._menuRepository.Remove(menu);
            }
            catch (Exception ex)
            {

                result.Success = false;
                result.Message = "Error removiendo el curso.";
                this._logger.LogError(message: result.Message, ex.ToString());
            }

            return result;
        }

        public Core.ServiceResult SaveMenu(MenuSaveDto menuSaveDto)
        {
            ServiceResult result = new ServiceResult();

            try
            {

                result = menuSaveDto.IsValidMenus();

                if (!result.Success)
                    return result;


                Domain.Entities.Menu menu = new Domain.Entities.Menu();
                {
                    menu.IdPlato = (int)menuSaveDto.IdPlato;
                    menu.Precio = (decimal)menuSaveDto.Precio;
                    menu.Nombre = menuSaveDto.Nombre;
                    menu.Descripcion = menuSaveDto.Descripcion;
                    menu.creation_user = menuSaveDto.creation_user;
                    menu.creation_date = menuSaveDto.creation_date;

                };

                this._menuRepository.Save(menu);

            }
            catch (Exception ex)
            {

                result.Success = false;
                result.Message = "Error guardando Los menus.";
                this._logger.LogError(message: result.Message, ex.ToString());
            }


            return result;
        }

        public Core.ServiceResult UptadeMenu(MenuUpdateDto menuUpdateDto)
        {
            ServiceResult result = new ServiceResult();

            try
            {

                result = menuUpdateDto.IsValidMenus();

                if (!result.Success)
                    return result;


                Domain.Entities.Menu menu = new Domain.Entities.Menu();
                {
                    menu.IdPlato = (int)menuUpdateDto.IdPlato;
                    menu.Precio = (decimal)menuUpdateDto.Precio;
                    menu.Nombre = menuUpdateDto.Nombre;
                    menu.Descripcion = menuUpdateDto.Descripcion;
                    menu.modify_date = menuUpdateDto.ModifyDate;
              
                };

                this._menuRepository.Save(menu);

            }
            catch (Exception ex)
            {

                result.Success = false;
                result.Message = "Error guardando Los menus.";
                this._logger.LogError(message: result.Message, ex.ToString());
            }


            return result;

        }
    }
}