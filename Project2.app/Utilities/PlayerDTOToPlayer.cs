using Project2.app.Models;
using Project2.app.Models.DTO;

namespace Project2.app.Utilities;

public static class PlayerDTOToPlayer
{
    public static Player DTOToPlayer(PlayerDTO playerDTO)
    {
        Player newPlayer = new()
        {
            Name = playerDTO.Name
        };
        return newPlayer;
    }
}