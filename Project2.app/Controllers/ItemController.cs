using Microsoft.AspNetCore.Mvc;
using Project2.app.Models;
using Project2.app.Services.Interface;

namespace Project2.app.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ItemController : ControllerBase
    {
        private readonly IService<Item> _itemService;

        public ItemController(IService<Item> itemService)
        {
            _itemService = itemService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var items = await _itemService.GetAllEntities();
                return Ok(items);
            }
            catch (Exception ex)
            {
                // Log the exception (optional)
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("{item_id}")]
        public async Task<IActionResult> GetItem(int item_id)
        {
            try
            {
                var item = await _itemService.GetEntityById(item_id);

                if (item == null)
                {
                    return NotFound("Item doesn't Exist");
                }
                return Ok(item);
            }
            catch (Exception ex)
            {
                // Log the exception (optional)
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
