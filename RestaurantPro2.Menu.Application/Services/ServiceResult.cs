using RestaurantPro2.Menu.Application.Core;
using RestaurantPro2.Menu.Application.Dtos;
using RestaurantPro2.Menu.Application.Interfaces;

namespace RestaurantPro2.Menu.Application.Services
{
    public class ServiceResult :IMenuService
    {

        private readonly IMenuDb MenuDb;
      
         public ServiceResult()
        {
        }

        public ServiceResult(IMenuDb MenuDb)
        {
            this.MenuDb = MenuDb;
        }

        public bool Sucess { get; set; }

        public ServiceResult GetMenu(int id)
        {
            Service result = new Service();
            try
            {
                result.Data = MenuDb.GetMenu(id);
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Ocurrio un error obteniendo el cliente";

            }
            return result;
        }

        public ServiceResult GetMenus()
        {
            ServiceResult result = new ServiceResult();
            try
            {
                result.Data = MenuDb.GetMenu();
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Ocurrio un error obteniendo los Menus";

            }
            return result;
        }

        public ServiceResult RemoveMenu(MenuRemoveDto menuRemoveModelcs)
        {
            Service result = new Service();
            try
            {
                result.Data = MenuDb.Remove(menuRemoveModelcs);
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Ocurrio un error eliminando los datos";

            }
            return result;
        }

        public ServiceResult SaveMenu(MenuSaveDto menuSaveModel)
        {
            Service result = new Service();
            try
            {
                result.Data = MenuDb.Save(menuSaveModel);
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Ocurrio un error removiendo los datos";

            }
            return result;
        }

        public ServiceResult UptadeMenu(MenuUpdateDto menuUpdateModel)
        {
            Service result = new Service();
            try
            {
                result.Data = MenuDb.Uptade(menuUpdateModel);
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Ocurrio un error actualizando los datos";

            }
            return result;
        }

    }
}