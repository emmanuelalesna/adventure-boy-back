using Microsoft.AspNetCore.Identity;
using Project2.app.DTOs;
using Project2.app.Models;

namespace Project2.app.Services.Interface;

public interface IService<Type>
{
    Task<Type> CreateNewEntity(Type entityToCreate);

    Task<Type?> DeleteEntity(int id);

    Task<Type?> UpdateEntity(int id, Dictionary<string, object> updates);

    Task<Type?> GetEntityById(int id);

    Task<List<Type>> GetAllEntities();
}

public interface IPlayerService : IService<Player>
{
    Task<Player?> GetEntityById(string account, int id);
    Task<List<Player>> GetAllEntities(string id);
    Task<Player?> UpdatePlayerName(int id, string name);
}

public interface IAccountService
{
    Task<IdentityResult> CreateNewEntity(AccountDTO entityToCreate);
    Task<Account?> DeleteEntity(string id);
    Task<Account?> UpdateEntity(string id, Dictionary<string, object> updates);
    Task<Account?> GetEntityById(string id);
    Task<List<Account>> GetAllEntities();
    Task<Account?> GetEntityByUsername(string username);
    Task<SignInResult> Login(AccountDTO account);
    Task Logout();
}