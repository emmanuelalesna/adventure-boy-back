using Project2.app.DTOs;
using Project2.app.Models;

namespace Project2.app.Utilities;

public static class DTOUtilities
{
    public static Account DTOToAccount(AccountDTO accountDTO)
    {
        Account account = new() { AccountId = accountDTO.AccountId, Username = accountDTO.Username, Password = accountDTO.Password, OwnedPlayer = accountDTO.OwnedPlayer };
        return account;
    }
}