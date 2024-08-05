using Project2.app.DataAccess;
using Project2.app.Models;
using Project2.app.Services.Interface;

namespace Project2.app.Services;

public class AccountService(IRepo<Account> IAccountRepo) : IService<Account>
{
    private readonly IRepo<Account> _AccountRepo = IAccountRepo;
    public async Task<Account> CreateNewEntity(Account entityToCreate)
    {
        try
        {
            if (entityToCreate.Username != null && entityToCreate.Password != null)
            {
                return await _AccountRepo.CreateEntity(entityToCreate);
            }
            else
            {
                throw new InvalidDataException("Username and/or password cannot be empty.");
            }
        }
        catch (InvalidDataException e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task<Account?> DeleteEntity(int id)
    {
        try
        {
            var account = await GetEntityById(id);
            if (account is null) return null;
            return await _AccountRepo.DeleteEntity(id);
        }
        catch (Exception)
        {
            throw;
        }
    }

    public Task<List<Account>> GetAllEntities()
    {
        throw new NotImplementedException();
    }

    public async Task<Account?> GetEntityById(int id)
    {
        return await _AccountRepo.GetById(id);
    }

    public Task<Account> UpdateEntity(int id, Dictionary<string, object> updates)
    {
        throw new NotImplementedException();
    }
}