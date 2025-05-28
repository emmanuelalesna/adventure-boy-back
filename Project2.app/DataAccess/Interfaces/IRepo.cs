using Project2.app.Models;

namespace Project2.app.DataAccess.Interfaces;

public interface IRepo<Type>
{
    Task<Type> CreateEntity(Type entity);
    Task<Type?> GetById(int id);
    Task<List<Type>> GetAllEntities();
    Task<Type?> UpdateEntity(int id, Dictionary<string, object> updates);
    Task<Type?> DeleteEntity(int id);
}

public interface IPlayerRepo : IRepo<Player>
{
    Task<Player?> GetById(string account, int id);
    Task<List<Player>> GetAllEntities(string id);
    Task<Player?> UpdatePlayerName(int id, string name);
}

public interface IAccountRepo
{
    Task<Account> CreateEntity(Account entity);
    Task<Account?> GetById(string id);
    Task<Account?> GetByUsername(string username);
    Task<List<Account>> GetAllEntities();
    Task<Account?> UpdateEntity(string id, Dictionary<string, object> updates);
    Task<Account?> DeleteEntity(string id);
    Task<Account?> LoginUser(Account user);
}