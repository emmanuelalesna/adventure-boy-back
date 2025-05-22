using Microsoft.EntityFrameworkCore;
using Project2.app.DataAccess.Interfaces;
using Project2.app.Models;

namespace Project2.app.DataAccess;

public class AccountRepo(ApplicationDbContext context) : IAccountRepo
{
    private readonly ApplicationDbContext _context = context;

    public async Task<Account> CreateEntity(Account account)
    {
        _context.Users.Add(account);
        await _context.SaveChangesAsync();
        return account;
    }

    public async Task<Account?> DeleteEntity(string id)
    {
        var toDelete = await GetById(id);
        if (toDelete is null) return null;
        _context.Users.Remove(toDelete);
        await _context.SaveChangesAsync();
        return toDelete;
    }
    public async Task<Account?> GetByUsername(string username)
    {
        return await _context.Users.Include(a => a.OwnedPlayer).FirstOrDefaultAsync(a => a.FirstName == username);
    }
    public async Task<List<Account>> GetAllEntities()
    {
        return await _context.Users.ToListAsync();
    }

    public async Task<Account?> GetById(string id)
    {
        return await _context.Users.Include(a => a.OwnedPlayer).FirstOrDefaultAsync(t => t.Id == id);
    }

    public async Task<Account?> UpdateEntity(string id, Dictionary<string, object> updates)
    {
        var originalAccount = await GetById(id);

        if (originalAccount != null)
        {
            foreach (var update in updates)
            {
                var property = originalAccount.GetType().GetProperty(update.Key);
                if (property != null & property.CanWrite)
                {
                    property.SetValue(originalAccount, update.Value);
                }

            }
            await _context.SaveChangesAsync();
        }
        return null;
    }

    public Task<Account?> LoginUser(Account account)
    {
        // return _context.Accounts.Include(a => a.OwnedPlayer).FirstOrDefaultAsync(a => a.FirstName == account.FirstName && a.Password == account.Password);
        throw new NotImplementedException();
    }
}