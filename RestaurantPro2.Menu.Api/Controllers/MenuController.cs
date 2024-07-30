using Microsoft.AspNetCore.Mvc;
using RestaurantPro2.menu.Application.Contracts;
using RestaurantPro2.menu.Application.Dtos;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RestaurantPro2.menu.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuController : ControllerBase
    {
        private readonly IMenuService menuService;
        public MenuController(IMenuService menuService)
        {
            this.menuService = menuService;
        }

        [HttpGet("GetMenu")]
        public IActionResult Get()
        {
            var result = this.menuService.GetMenu();

            if (!result.Success)
                return BadRequest(result);
            else
                return Ok(result);

        }


        [HttpGet("GetCourseById")]
        public IActionResult Get(int id)
        {
            var result = this.menuService.GetMenuById(id);

            if (!result.Success)
                return BadRequest(result);
            else
                return Ok(result);
        }


        [HttpPost("SaveMenu")]
        public IActionResult Post([FromBody] MenuSaveDto menuSaveDto)
        {
            var result = this.menuService.SaveMenu(menuSaveDto);

            if (!result.Success)
                return BadRequest(result);
            else
                return Ok(result);
        }


        [HttpPost("UpdateMenu")]
        public IActionResult Put(MenuUpdateDto menuUpdate)
        {
            var result = this.menuService.UptadeMenu(menuUpdate);

            if (!result.Success)
                return BadRequest(result);
            else
                return Ok(result);
        }

        [HttpPost("RemoveMenu")]
        public IActionResult Delete(MenuRemoveDto menuRemove)
        {
            var result = this.menuService.MenuRemove(menuRemove);

            if (!result.Success)
                return BadRequest(result);
            else
                return Ok(result);
        }
    }



}