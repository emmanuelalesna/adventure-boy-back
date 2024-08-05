using Microsoft.AspNetCore.Mvc;
using Project2.app.Models;
using Project2.app.Services;
using Project2.app.Services.Interface;

namespace Project2.app.Controllers;

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