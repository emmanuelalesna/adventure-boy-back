using Microsoft.AspNetCore.Mvc;
using Project2.app.Models;
using Project2.app.Services.Interface;

namespace Project2.app.Controllers;

[ApiController]
[Route ("api/[controller]")]
public class PlayerController(IService<Player> playerService) : ControllerBase
{
    private readonly IService<Player> _playerService = playerService;

    [HttpPost]
    public async Task<IActionResult> CreatePlayer(Player player)
    {
        return Ok(await _playerService.CreateNewEntity(player));
    }
}