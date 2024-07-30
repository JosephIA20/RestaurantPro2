using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RestaurantPro2.wep.Models.Results;
using RestaurantPro2.wep.Models.Save;
using RestaurantPro2.wep.Models.Uptade;
using System.Net.Http;
using System.Threading.Tasks;

namespace RestaurantPro2.wep.Services
{
    public class MenuServiceWep
    {
        private readonly HttpClient _httpClient;

        public MenuServiceWep(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<MenuGetResult> Index()
        {
            var url = "http://localhost:5073/api/Menu/GetMenu";

            using (var response = await _httpClient.GetAsync(url))
            {
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    var menuGetResult = JsonConvert.DeserializeObject<MenuGetResult>(apiResponse);

                    if (menuGetResult != null && menuGetResult.success)
                    {
                        return menuGetResult;
                    }
                    else
                    {
                        throw new Exception(menuGetResult?.message ?? "Hubo un error en su API");
                    }
                }
                else
                {
                    throw new Exception("Fallo en obtener los menús de la API");
                }
            }
        }

        public async Task<MenuGetResult> Details(int id)
        {
            var url = $"http://localhost:5142/api/Menu/GetMenubyId?id={id}";

            using (var response = await _httpClient.GetAsync(url))
            {
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    var menuGetResult = JsonConvert.DeserializeObject<MenuGetResult>(apiResponse);

                    if (menuGetResult != null && menuGetResult.success)
                    {
                        return menuGetResult;
                    }
                    else
                    {
                        throw new Exception(menuGetResult?.message ?? "Error en su API");
                    }
                }
                else
                {
                    throw new Exception("Fallo en obtener los detalles de su API");
                }
            }
        }

        public async Task<MenuUpdateModel> Edit(int id)
        {
            MenuGetResult menuGetResult;
            var url = $"http://localhost:5142/api/Menu/UpdateMenu?id={id}";

            using (var response = await _httpClient.GetAsync(url))
            {
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    menuGetResult = JsonConvert.DeserializeObject<MenuGetResult>(apiResponse);

                    if (menuGetResult != null && menuGetResult.success)
                    {
                        var menuUpdateModel = new MenuUpdateModel
                        {
                            // Map the properties from menuGetResult to menuUpdateModel
                        };

                        return menuUpdateModel;
                    }
                    else
                    {
                        throw new Exception(menuGetResult?.message ?? "Error en su API");
                    }
                }
                else
                {
                    throw new Exception("Fallo en obtener los detalles del menú de la API");
                }
            }
        }

        public async Task<ActionResult> Create(MenuSaveModel menuSave)
        {
            if (!menuSave.IsValid)
            {
                return new ViewResult { ViewName = "Create", ViewData = { Model = menuSave } }; // Devuelve la vista con errores de validación
            }

            try
            {
                var url = "http://localhost:5073/api/Menu/SaveMenu";
                var jsonContent = JsonConvert.SerializeObject(menuSave);
                var content = new StringContent(jsonContent, System.Text.Encoding.UTF8, "application/json");

                using (var response = await _httpClient.PostAsync(url, content))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        // Redirige a la lista después de una creación exitosa
                        return new RedirectToActionResult("Index", "Menu", null);
                    }
                    else
                    {
                       
                        return new ViewResult { ViewName = "Create", ViewData = { Model = menuSave } };
                    }
                }
            }
            catch (Exception ex)
            {
              
                return new ViewResult { ViewName = "Create", ViewData = { Model = menuSave } };
            }
        }
    }
}
