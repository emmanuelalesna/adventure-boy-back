namespace Project2.app.Models;

public class Spell
{
    public int SpellId { get; set; }
    public string SpellIndex { get; set; }
    public int Cost { get; set; }
    public List<Player> Players { get; set; } = [];
}