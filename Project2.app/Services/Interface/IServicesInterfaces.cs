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

public interface IAccountService
{
    Task<Account> CreateNewEntity(Account entityToCreate);
    Task<Account?> DeleteEntity(int id);
    Task<Account?> UpdateEntity(int id, Dictionary<string, object> updates);
    Task<Account?> GetEntityById(int id);
    Task<List<Account>> GetAllEntities();
    Task<Account?> GetEntityByUsername(string username);
    Task<Account?>Login(Account account);
}