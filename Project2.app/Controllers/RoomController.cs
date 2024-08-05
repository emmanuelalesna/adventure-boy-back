using Microsoft.AspNetCore.Mvc;
using Project2.app.Models;
using Project2.app.Services;

namespace Project2.app.Controllers;

public class RoomController : ControllerBase
{
    private readonly ILogger<RoomController> _logger;
    private readonly RoomService _roomService;

    public RoomController(ILogger<RoomController> logger, RoomService roomService)
    {
        _logger = logger;
        _roomService = roomService;
    }

    [HttpGet("/GetRooms")]
    public IActionResult GetAll()
    {
        return Ok(_roomService.GetAllEntities());
    }

    [HttpGet("GetRooms/{room_id}")]
    public IActionResult GetRoom(int room_id)
    {
        var room = _roomService.GetEntityById(room_id);

        if (room is null) return NotFound("Room doesn't Exist");
        return Ok(room);
    }
}
