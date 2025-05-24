using Project2.app.Models;

namespace Project2.app.DTOs;

public class PlayerDTO
{
    public int? PlayerId { get; set; }
    public string? Name { get; set; }
    public int? CurrentHealth { get; set; } = 10;
    public int? CurrentMana { get; set; } = 1;
    public int? CurrentRoom { get; set; } = 0;
}