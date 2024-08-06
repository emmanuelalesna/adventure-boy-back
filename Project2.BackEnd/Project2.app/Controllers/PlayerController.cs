using Microsoft.AspNetCore.Mvc;
using Project2.app.Models;
using Project2.app.Services.Interface;

namespace Project2.app.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PlayerController(IService<Player> playerService) : ControllerBase
{
    private readonly IService<Player> _playerService = playerService;

    [HttpPost]
    public async Task<IActionResult> CreatePlayer(Player player)
    {
        return Ok(await _playerService.CreateNewEntity(player));
    }

    [HttpGet]
    public async Task<IActionResult> GetAllPlayers()
    {
        return Ok(await _playerService.GetAllEntities());
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetPlayerById(int id)
    {
        try
        {
            var player = await _playerService.GetEntityById(id);
            if (player is null) return NotFound("Player does not exist");
            return Ok(player);
        }
        catch (Exception e)
        {
            return BadRequest(e);
        }
    }

}