using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace Project2.app.Models;

public class Account : IdentityUser
{
    // [Key]
    // public int? AccountId { get; set; }
    public string? FirstName { get; set; }
    public ICollection<Player> Players { get; set; } = [];
}