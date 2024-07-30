using RestaurantPro2.menu.Application.Core;
using RestaurantPro2.menu.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantPro2.Menu.Application.Validaciones
{
    public static class ValidMenus
    {

        public static ServiceResult IsValidMenus(this MenuModelBase menuDto)
        {
            ServiceResult result = new ServiceResult();

            if (menuDto is null)
            {
                result.Success = false;
                result.Message = $"El objeto{nameof(menuDto)} es requerido.";
                return result;
            }

            if (string.IsNullOrEmpty(menuDto?.Nombre))
            {
                result.Success = false;
                result.Message = $"El Nombre del Menu es requerido.";
                return result;
            }

            if (menuDto?.Precio == 0 || menuDto?.Precio < 0)
            {
                result.Success = false;
                result.Message = $"El precio del menu no puede ser cero o negativo.";
                return result;
            }
            if (menuDto?.IdPlato == 0)
            {
                result.Success = false;
                result.Message = $"Debe seleccionar el Menu .";
                return result;
            }


            return result;
        }
    }

}

