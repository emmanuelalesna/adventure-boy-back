using Microsoft.AspNetCore.Mvc;
using Project2.app.Models;
using Project2.app.Services.Interface;

namespace Project2.app.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RoomController : ControllerBase
{
    private readonly IService<Room> _roomService;

    public RoomController(IService<Room> roomService)
    {
        _roomService = roomService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllRooms()
    {
        return Ok(await _roomService.GetAllEntities());
    }

    [HttpGet("{room_id}")]
    public async Task<IActionResult> GetRoom(int room_id)
    {
    try
        {
            var room = await _roomService.GetEntityById(room_id);
            if (room is null) return NotFound("Room doesn't Exist");
            return Ok(room);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }   
    }


}
