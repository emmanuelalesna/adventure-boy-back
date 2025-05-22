using Microsoft.AspNetCore.Mvc;
using Project2.app.Models;
using Project2.app.Services.Interface;

namespace Project2.app.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PlayerController(IPlayerService playerService) : ControllerBase
{
    private readonly IPlayerService _playerService = playerService;

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
    public async Task<IActionResult> GetPlayerById(string id)
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
    [HttpPatch]
    public async Task<IActionResult> ChangePlayerById(Player player)
    {
        Dictionary<string, object> toEdit = [];
        toEdit.Add("CurrentRoom", player.CurrentRoom);
        toEdit.Add("CurrentHealth", player.CurrentHealth);
        toEdit.Add("CurrentMana", player.CurrentMana);
        var updatedPlayer = await _playerService.UpdateEntity(player.PlayerId, toEdit);
        if (updatedPlayer is null) return NotFound("Player cannot be found!");
        return Ok(updatedPlayer);
    }
}