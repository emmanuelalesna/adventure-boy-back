namespace Project2.app.Models;

public class Player
{
    public int PlayerId { get; set; }
    public required string AccountId { get; set; }
    public required string Name { get; set; }
    public int CurrentHealth { get; set; } = 10;
    public int CurrentMana { get; set; } = 1;
    public int CurrentRoom { get; set; } = 0;
    public int CurrentEnemyHealth { get; set; }
    // public Account? Account { get; set; } = null!;
}