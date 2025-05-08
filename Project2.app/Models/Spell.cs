using System.ComponentModel.DataAnnotations;

namespace Project2.app.Models;

public class Spell
{
    [Key]
    public int SpellId { get; set; }
    public string SpellName { get; set; }
    public int Attack { get; set; }
    public int ManaCost { get; set; }
    public string ImageUrl { get; set; }

}