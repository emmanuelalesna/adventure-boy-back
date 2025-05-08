using Project2.app.Models;

namespace Project2.app.DTOs;

public class AccountDTO
{
    public required int AccountId { get; set; }
    public required string Username { get; set; }
    public string? Password { get; set; }
    public Player? OwnedPlayer { get; set; }
}