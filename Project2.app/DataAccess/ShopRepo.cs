using Microsoft.EntityFrameworkCore;
using Project2.app.DataAccess.Interfaces;
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

    public async Task<Shop?> DeleteEntity(int id)
    {
        var toDelete = await GetById(id);
        if (toDelete is null) return null;
        _context.Shops.Remove(toDelete);
        await _context.SaveChangesAsync();
        return toDelete;
    }

    public async Task<List<Shop>> GetAllEntities()
    {
        return await _context.Shops.ToListAsync();
    }

    public async Task<Shop?> GetById(int id)
    {
        return await _context.Shops.FirstOrDefaultAsync(t => t.ShopId == id);
    }

    public async Task<Shop?> UpdateEntity(int id, Dictionary<string, object> updates)
    {
        var originalShop = await GetById(id);

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
            await _context.SaveChangesAsync();
        }
        return null;
    }
}