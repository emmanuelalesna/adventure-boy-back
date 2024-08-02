namespace Project2.app.Models;

public class Spell
{
    public int SpellId { get; set; }
    public string Name { get; set; }
    public string? Description { get; set; }
    public int? Damage { get; set; }
    public string? School { get; set; }
    public int Cost { get; set; }
    public List<Player> Players { get; set; } = [];
}