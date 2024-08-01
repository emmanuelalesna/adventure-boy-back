namespace Project2.app.Models;

public class Item
{
    public int ItemId { get; set; }
    public string Name { get; set; }
    public int DefenseBoost { get; set; }
    public int AttackBoost { get; set; }
    public int HealthBoost { get; set; }
    public int Cost { get; set; }
    public string ImageUrl { get; set; }
}