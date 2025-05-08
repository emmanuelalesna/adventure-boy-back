using System.ComponentModel.DataAnnotations;

namespace Project2.app.Models;

public class Enemy
{
    [Key]
    public int EnemyId { get; set; }
    public string EnemyName { get; set; }
    public int Attack { get; set; }
    public int Health { get; set; }
    public string ImageUrl { get; set; }
}