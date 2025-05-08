using System.ComponentModel.DataAnnotations;

namespace Project2.app.Models;

public class Item
{
    [Key]
    public int ItemId { get; set; }
    public string ItemName { get; set; }
    public int Attack { get; set; }
    public string ImageUrl { get; set; }
}