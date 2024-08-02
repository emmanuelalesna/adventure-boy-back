using Microsoft.EntityFrameworkCore;
using Project2.app.Models;

namespace Project2.app.DataAccess;

public class ShopRepo(ApplicationDbContext context) : IRepo<Shop>
{

    private readonly ApplicationDbContext _context = context;

    public async Task<Shop> CreateEntity(Shop shop)
    {
        _context.Shops.Add(shop);
        await _context.SaveChangesAsync();
        return shop;
    }

    public async Task<Shop> DeleteEntity(int id)
    {
        Shop toDelete = _context.Shops.Find(id);
        _context.Shops.Remove(toDelete);
        await _context.SaveChangesAsync();
        return toDelete;
    }

    public async Task<List<Shop>> GetAllEntities()
    {
        return await _context.Shops
            .Include(s => s.Items)
            .ToListAsync();
    }

    public async Task<Shop> GetById(int id)
    {
        return await _context.Shops
            .Include(s => s.Items)
            .FirstOrDefaultAsync(t => t.ShopId == id);
    }

    /* public Task<Player> UpdateEntity(int id, Player updatePlayer)
    {
        Player oldPlayer = _context.Players.Find(id)!;
        oldPlayer.Health = updateTrainer.Username;
        oldPlayer.Level = updateTrainer.Password;
        await _context.SaveChangesAsync();
        return oldTrainer;
    } */
    public async Task<Shop> UpdateEntity(int id, Dictionary<string, object> updates)
    {
        Shop originalShop = _context.Shops.FirstOrDefault(p => p.ShopId == id);

        if (originalShop != null)
        {
            foreach (var update in updates)
            {
                var property = originalShop.GetType().GetProperty(update.Key);
                if (property != null & property.CanWrite)
                {
                    property.SetValue(originalShop, update.Value);
                }

            }
        }
        await _context.SaveChangesAsync();
        return originalShop;
    }
}