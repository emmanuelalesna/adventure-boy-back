using Project2.app.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using Project2.app.Models;

namespace Project2.app.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ShopController(IService<Shop> shopService) : ControllerBase
{
    private readonly IService<Shop> _shopService = shopService;

    [HttpGet]
    public async Task<IActionResult> GetAllShops()
    {
        return Ok(await _shopService.GetAllEntities());
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetShopById(int id)
    {
        try
        {
            var shop = await _shopService.GetEntityById(id);
            if (shop is null)
            {
                return NotFound("Shop does not exist!");
            }
            return Ok(shop);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
}