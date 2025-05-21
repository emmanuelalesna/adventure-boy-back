using Project2.app.DTOs;
using Project2.app.Models;

namespace Project2.app.Utilities;

public static class DTOUtilities
{
    public static Account DTOToAccount(AccountDTO accountDTO)
    {
        Account account = new() { AccountId = accountDTO.AccountId, FirstName = accountDTO.Username, Password = accountDTO.Password, OwnedPlayer = accountDTO.OwnedPlayer, UserName = accountDTO.Username };
        return account;
    }
}