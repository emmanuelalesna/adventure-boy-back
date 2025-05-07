using System.ComponentModel.DataAnnotations;

namespace Project2.app.Models;

public class Player
{
    [Key]
    public int PlayerId { get; set; }
    public required string Name { get; set; }
    public int CurrentHealth { get; set; } = 10;
    public int CurrentMana { get; set; } = 1;
    public int CurrentRoom { get; set; } = 0;
    public int CurrentEnemyHealth { get; set; }
    public Account? AccountOwner { get; set; }
}