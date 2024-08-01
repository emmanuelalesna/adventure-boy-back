namespace Project2.app.Models;

public class Shop
{
    public int ShopId { get; set; }
    public int RefundPercentage { get; set; }
    public string Description { get; set; }
    public string ShopkeeperImageUrl { get; set; }
    public string BackgroundImageUrl { get; set; }
    public List<Item> Items { get; set; }
}