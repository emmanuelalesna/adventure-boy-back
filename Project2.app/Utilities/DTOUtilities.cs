using Project2.app.DTOs;
using Project2.app.Models;

namespace Project2.app.Utilities;

public static class DTOUtilities
{
    public static Account DTOToAccount(AccountDTO accountDTO)
    {
        Account account = new() { UserName = accountDTO.UserName, FirstName = accountDTO.FirstName, OwnedPlayer = accountDTO.OwnedPlayer };
        return account;
    }
}