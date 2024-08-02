using Microsoft.EntityFrameworkCore;
using Project2.app.Models;

namespace Project2.app.DataAccess;

public class AccountRepo(ApplicationDbContext context) : IRepo<Account>
{
    private readonly ApplicationDbContext _context = context;

    public async Task<Account> CreateEntity(Account account)
    {
        _context.Accounts.Add(account);
        await _context.SaveChangesAsync();
        return account;
    }

    public async Task<Account> DeleteEntity(int id)
    {
        Account toDelete = _context.Accounts.Find(id);
        _context.Accounts.Remove(toDelete);
        await _context.SaveChangesAsync();
        return toDelete;
    }

    public async Task<List<Account>> GetAllEntities()
    {
        return await _context.Accounts.ToListAsync();
    }

    public async Task<Account> GetById(int id)
    {
        return await _context.Accounts.FirstOrDefaultAsync(t => t.AccountId == id);
    }

    public async Task<Account> UpdateEntity(int id, Dictionary<string, object> updates)
    {
         Account originalAccount = _context.Accounts.FirstOrDefault(p => p.AccountId == id);

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
        }
        await _context.SaveChangesAsync();
        return originalAccount;
    }
}