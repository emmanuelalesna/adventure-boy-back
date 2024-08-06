namespace Project2.app.Models;

public class Player
{
    public int PlayerId { get; set; }
    public required string Name { get; set; }
    public int Level { get; set; } = 1;
    public int Exp { get; set; } = 0;
    public int CurrentHealth { get; set; } = 10;
    public int Gold { get; set; } = 0;
    public int CurrentRoom { get; set; } = 1;
    public List<Spell> Spells { get; set; } = [];
    public List<Item> Items { get; set; } = [];
    public Account? AccountOwner { get; set; }
}