using Project2.app.DTOs;
using Project2.app.Models;

namespace Project2.app.Utilities;

public static class DTOUtilities
{
    public static Account DTOToAccount(AccountDTO accountDTO)
    {
        return new() { UserName = accountDTO.UserName, FirstName = accountDTO.FirstName, Players = accountDTO.Players };
    }

    public static PlayerDTO PlayerToDTO(Player player)
    {
        return new() { PlayerId = player.PlayerId, Name = player.Name, CurrentHealth = player.CurrentHealth, CurrentMana = player.CurrentMana, CurrentRoom = player.CurrentRoom };
    }
}