using Microsoft.AspNetCore.Mvc;
using Project2.app.Models;
using Project2.app.Services;

namespace Project2.app.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RoomController : ControllerBase
{
    private readonly RoomService _roomService;

    public RoomController(RoomService roomService)
    {
        _roomService = roomService;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        return Ok(_roomService.GetAllEntities());
    }

    [HttpGet("{room_id}")]
    public async Task<IActionResult> GetRoom(int room_id)
    {
        var room = await _roomService.GetEntityById(room_id);

        if (room is null) return NotFound("Room doesn't Exist");
        return Ok(room);
    }
}
