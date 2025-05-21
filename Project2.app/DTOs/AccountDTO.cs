using Project2.app.Models;

namespace Project2.app.DTOs;

public class AccountDTO
{
    public int? AccountId { get; set; }
    public string? UserName { get; set; }
    public string? Password { get; set; }
    public string? FirstName { get; set; }
    public Player? OwnedPlayer { get; set; }
}