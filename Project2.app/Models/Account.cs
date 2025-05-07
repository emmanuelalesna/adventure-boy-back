using System.ComponentModel.DataAnnotations;

namespace Project2.app.Models;

public class Account
{
    [Key]
    public int AccountId { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
    public Player? OwnedPlayer { get; set; }
}