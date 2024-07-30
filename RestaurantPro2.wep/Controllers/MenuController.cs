using Microsoft.AspNetCore.Mvc;
using RestaurantPro2.wep.Models;
using RestaurantPro2.wep.Models.Save;
using RestaurantPro2.wep.Models.Uptade;
using RestaurantPro2.wep.Services;
using System.Threading.Tasks;

namespace RestaurantPro2.wep.Controllers
{
    public class MenuController : Controller
    {
        private readonly MenuServiceWep _menuService;

        public MenuController(MenuServiceWep menuService)
        {
            _menuService = menuService;
        }

        public async Task<IActionResult> Index()
        {
            var result = await _menuService.Index();
            return View(result);
        }

        public async Task<IActionResult> Details(int id, MenuModels menuModels)
        {
            var result = await _menuService.Details(id);
            return View(result);
        }

        public async Task<IActionResult> Edit(int id, MenuUpdateModel updateModel)
        {
            var result = await _menuService.Edit(id);
            if (result == null)
            {
                return NotFound();
            }

            return View(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create(MenuSaveModel menuSave)
        {
            if (!ModelState.IsValid)
            {
                return View(menuSave); 
            }

            try
            {
                var result = await _menuService.Create(menuSave);
                return result;
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = $"Error al crear el menú: {ex.Message}";
                return View(menuSave);
            }
        }
    }
}
