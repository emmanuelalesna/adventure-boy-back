using Project2.app.DataAccess.Interfaces;
using Project2.app.Models;
using Project2.app.Services.Interface;

namespace Project2.app.Services;

public class AccountService(IAccountRepo IAccountRepo) : IAccountService
{
    private readonly IAccountRepo _accountRepo = IAccountRepo;
    public async Task<Account> CreateNewEntity(Account entityToCreate)
    {
        try
        {
            if (entityToCreate.Username != null && entityToCreate.Password != null)
            {
                return await _accountRepo.CreateEntity(entityToCreate);
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
            return await _accountRepo.DeleteEntity(id);
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task<List<Account>> GetAllEntities()
    {
        return await _accountRepo.GetAllEntities();
    }

    public async Task<Account?> GetEntityByUsername(string username)
    {
        return await _accountRepo.GetByUsername(username);
    }

    public async Task<Account?> GetEntityById(int id)
    {
        return await _accountRepo.GetById(id);
    }

    public Task<Account?> UpdateEntity(int id, Dictionary<string, object> updates)
    {
        throw new NotImplementedException();
    }

    public async Task<Account?> Login(Account account)
    {
        return await _accountRepo.LoginUser(account);
    }
}