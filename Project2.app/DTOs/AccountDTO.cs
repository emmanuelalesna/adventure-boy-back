using Project2.app.Models;

namespace Project2.app.DTOs;

public class AccountDTO
{
    // public string? Id { get; set; }
    public string? UserName { get; set; }
    public string? Password { get; set; }
    public string? FirstName { get; set; }
    public ICollection<Player> Players { get; set; } = [];
}