using System.ComponentModel.DataAnnotations;

namespace Project2.app.Models;

public class Room
{
    [Key]
    public int RoomId { get; set; }
    public string ImageUrl { get; set; }
}