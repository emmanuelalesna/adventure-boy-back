namespace Project2.app.Models.DTO;


public class PlayerDTO
{
    public int Health { get; set; } = 100;
    public int Level { get; set; } = 1;
    public int Exp { get; set; } = 0;
    public int Mana { get; set; } = 0;
    public int Gold { get; set; } = 0;
    public Room CurrentRoom { get; set; }
}