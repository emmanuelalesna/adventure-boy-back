using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project2.app.Models;

public class Player
{
    [Key]
    public string PlayerId { get; set; }
    public required string Name { get; set; }
    public int CurrentHealth { get; set; } = 10;
    public int CurrentMana { get; set; } = 1;
    public int CurrentRoom { get; set; } = 0;
    public int CurrentEnemyHealth { get; set; }
    [ForeignKey("AccountID")]
    public Account? AccountOwner { get; set; }
}