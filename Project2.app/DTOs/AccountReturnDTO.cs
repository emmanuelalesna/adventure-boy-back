using Project2.app.Models;

namespace Project2.app.DTOs;

public class AccountReturnDTO
{
    public int? AccountId { get; set; }
    public string? Username { get; set; }
    public Player? OwnedPlayer { get; set; }
}