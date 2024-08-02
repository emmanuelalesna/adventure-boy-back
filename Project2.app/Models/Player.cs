namespace Project2.app.Models;

public class Player
{
    public int PlayerId { get; set; }
    public int Health { get; set; } = 100;
    public int Level { get; set; } = 1;
    public int Exp { get; set; } = 0;
    public int Mana { get; set; } = 0;
    public int Gold { get; set; } = 0;
    public Room CurrentRoom { get; set; }
    public List<Spell> Spells { get; set; } = [];
    public List<Item> Items {get;set;} = [];
}