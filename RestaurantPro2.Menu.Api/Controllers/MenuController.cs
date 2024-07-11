using Microsoft.AspNetCore.Mvc;
using RestaurantPro2.Menu.Application.Dtos;
using RestaurantPro2.Menu.Application.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RestauranteSol.Factura.api.Controllers
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
            var result = this.menuService.GetMenus();
            if (result.Sucess)
            {
                return BadRequest(result);
            }
            else
                return Ok(result);

        }


        [HttpGet("GetMenubyId")]
        public IActionResult Get(int id)
        {
            var result = this.menuService.GetMenu(id);
            if (result.Sucess)
            {
                return BadRequest(result);
            }
            else
                return Ok(result);
        }


        [HttpPost("SaveMenu")]
        public IActionResult Post([FromBody] MenuSaveDto menuSaveDto)
        {
            menuSaveDto.ChangeDate = DateTime.Now;
            menuSaveDto.ChangeUser = 1;
            var result = this.menuService.SaveMenu(menuSaveDto);
            if (result.Sucess)
            {
                return BadRequest(result);
            }
            else
                return Ok(result);
        }


        [HttpPost("UpdateMenu")]
        public IActionResult Put(MenuUpdateDto menuUpdate)
        {
            var result = this.menuService.UptadeMenu(menuUpdate);
            if (result.Sucess)
            {
                return BadRequest(result);
            }
            else
                return Ok(result);
        }

        [HttpPost("RemoveMenu")]
        public IActionResult Delete(MenuRemoveDto menuRemove)
        {
            var result = this.menuService.RemoveMenu(menuRemove);
            if (result.Sucess)
            {
                return BadRequest(result);
            }
            else
                return Ok(result);
        }
    }



}