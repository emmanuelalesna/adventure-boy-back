using Microsoft.AspNetCore.Mvc;
using Project2.app.Models;
using Project2.app.Services;

namespace Project2.app.Controllers;

public class ItemController : ControllerBase
{
    private readonly ILogger<ItemController> _logger;
    private readonly ItemService _itemService;

    public ItemController(ILogger<ItemController> logger, ItemService itemService)
    {
        _logger = logger;
        _itemService = itemService;
    }

    [HttpGet("/GetItems")]
    public IActionResult GetAll()
    {
        return Ok(_itemService.GetAllEntities());
    }

    [HttpGet("GetItems/{item_id}")]
    public IActionResult GetItem(int item_id)
    {
        var item = _itemService.GetEntityById(item_id);

        if (item is null) return NotFound("Item doesn't Exist");
        return Ok(item);
    }
}