namespace Project2.app.Models;

public class Player
{
    public int PlayerId { get; set; }
    public int Health { get; set; }
    public int Exp { get; set; }
    public int Mana { get; set; }
    public int CurrentLocation { get; set; }
    public List<Spell> Spells { get; set; } = [];
}