using Microsoft.AspNetCore.Identity;
using Project2.app.DataAccess.Interfaces;
using Project2.app.DTOs;
using Project2.app.Models;
using Project2.app.Services.Interface;
using Project2.app.Utilities;

namespace Project2.app.Services;

public class AccountService(IAccountRepo IAccountRepo, SignInManager<Account> signInManager, UserManager<Account> userManager) : IAccountService
{
    private readonly IAccountRepo _accountRepo = IAccountRepo;
    private readonly SignInManager<Account> _signInManager = signInManager;
    private readonly UserManager<Account> _userManager = userManager;

    public async Task<IdentityResult> CreateNewEntity(AccountDTO entityToCreate)
    {
        try
        {
            if (entityToCreate.Username != null && entityToCreate.Password != null)
            {
                Account account1 = DTOUtilities.DTOToAccount(entityToCreate);
                // return await _accountRepo.CreateEntity(account1);
                Console.WriteLine(account1);
                Console.WriteLine(entityToCreate.Username);
                return await _userManager.CreateAsync(account1, entityToCreate.Password);
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

    public async Task<Account?> Login(AccountDTO accountDTO)
    {
        if (accountDTO.Username is not null && accountDTO.Password is not null)
        {
            Account account1 = DTOUtilities.DTOToAccount(accountDTO);
            return await _accountRepo.LoginUser(account1);
        }
        else
        {
            throw new InvalidDataException("login information is incomplete");
        }
    }
}