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
            if (entityToCreate.UserName != null && entityToCreate.Password != null)
            {
                Account account1 = DTOUtilities.DTOToAccount(entityToCreate);
                // return await _accountRepo.CreateEntity(account1);
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

    public async Task<Account?> DeleteEntity(string id)
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

    public async Task<Account?> GetEntityById(string id)
    {
        return await _accountRepo.GetById(id);
    }

    public Task<Account?> UpdateEntity(string id, Dictionary<string, object> updates)
    {
        throw new NotImplementedException();
    }

    public async Task<SignInResult> Login(AccountDTO accountDTO)
    {
        if (accountDTO.UserName is not null && accountDTO.Password is not null)
        {
            Account account1 = DTOUtilities.DTOToAccount(accountDTO);
            // return await _accountRepo.LoginUser(account1);
            Console.WriteLine(account1.UserName);
            Console.WriteLine(accountDTO.Password);
            return await _signInManager.PasswordSignInAsync(account1.UserName, accountDTO.Password, false, false);
        }
        else
        {
            throw new InvalidDataException("login information is incomplete");
        }
    }
}