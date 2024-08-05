using Microsoft.AspNetCore.Mvc;
using Project2.app.Models;
using Project2.app.Services;

namespace Project2.app.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ItemController : ControllerBase
{
    private readonly ItemService _itemService;

    public ItemController(ItemService itemService)
    {
        _itemService = itemService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await _itemService.GetAllEntities());
    }

    [HttpGet("{item_id}")]
    public async Task<IActionResult> GetItem(int item_id)
    {
        var item = await _itemService.GetEntityById(item_id);

        if (item is null) return NotFound("Item doesn't Exist");
        return Ok(item);
    }
}