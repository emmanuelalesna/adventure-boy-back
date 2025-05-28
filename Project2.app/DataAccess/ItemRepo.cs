using Microsoft.EntityFrameworkCore;
using Project2.app.DataAccess.Interfaces;
using Project2.app.Models;

namespace Project2.app.DataAccess;

public class ItemRepo(ApplicationDbContext context) : IRepo<Item>
{
    private readonly ApplicationDbContext _context = context;
    public async Task<Item> CreateEntity(Item item)
    {
        _context.Items.Add(item);
        await _context.SaveChangesAsync();
        return item;
    }

    public async Task<Item?> DeleteEntity(int id)
    {
        var toDelete = await GetById(id);
        if (toDelete is null) return null;
        _context.Items.Remove(toDelete);
        await _context.SaveChangesAsync();
        return toDelete;
    }

    public async Task<List<Item>> GetAllEntities()
    {
        return await _context.Items
            .ToListAsync();
    }

    public async Task<Item?> GetById(int id)
    {
        return await _context.Items
            .FirstOrDefaultAsync(i => i.ItemId == id);
    }

    public async Task<Item?> UpdateEntity(int id, Dictionary<string, object> updates)
    {
        var originalItem = await GetById(id);

        if (originalItem != null)
        {
            foreach (var update in updates)
            {
                var property = originalItem.GetType().GetProperty(update.Key);
                if (property != null & property.CanWrite)
                {
                    property.SetValue(originalItem, update.Value);
                }

            }
            await _context.SaveChangesAsync();
        }
        return null;
    }
}