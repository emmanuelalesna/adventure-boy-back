namespace Project2.app.Models;

public class Spell
{
    public int SpellId { get; set; }
    public string SpellIndex { get; set; }
    public string ImageUrl { get; set; }
    public List<Player> Players { get; set; } = [];
}