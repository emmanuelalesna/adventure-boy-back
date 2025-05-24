using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Project2.app.DTOs;
using Project2.app.Models;
using Project2.app.Services.Interface;
using Project2.app.Utilities;

namespace Project2.app.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PlayerController(IPlayerService playerService) : ControllerBase
{
    private readonly IPlayerService _playerService = playerService;

    [HttpPost, Authorize]
    public async Task<IActionResult> CreatePlayer(Player player)
    {
        try
        {
            var newPlayer = await _playerService.CreateNewEntity(player);
            var routeValues = new
            {
                action = "GetPlayerById",
                accountId = newPlayer.AccountId,
                playerId = newPlayer.PlayerId
            };
            return CreatedAtAction(nameof(GetPlayerById), routeValues, DTOUtilities.PlayerToDTO(newPlayer));
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpGet("{accountId}/all"), Authorize]
    public async Task<IActionResult> GetAllPlayers(string accountId)
    {
        try
        {
            var res = await _playerService.GetAllEntities(accountId);
            var playerList = res.Select(i => DTOUtilities.PlayerToDTO(i));
            return Ok(playerList);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
    [HttpGet("{accountId}"), Authorize]
    public async Task<IActionResult> GetPlayerById(string accountId, [FromQuery] int playerId)
    {
        try
        {
            var player = await _playerService.GetEntityById(accountId, playerId);
            if (player is null) return NotFound("Player does not exist");
            PlayerDTO playerDTO = DTOUtilities.PlayerToDTO(player);
            return Ok(playerDTO);
        }
        catch (Exception e)
        {
            return BadRequest(e);
        }
    }
    [HttpPatch, Authorize]
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