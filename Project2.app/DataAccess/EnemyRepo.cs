using Microsoft.EntityFrameworkCore;
using Project2.app.DataAccess.Interfaces;
using Project2.app.Models;

namespace Project2.app.DataAccess;

public class EnemyRepo(ApplicationDbContext context) : IRepo<Enemy>
{
    private readonly ApplicationDbContext _context = context;
    public async Task<Enemy> CreateEntity(Enemy enemy)
    {
        _context.Enemies.Add(enemy);
        await _context.SaveChangesAsync();
        return enemy;
    }

    public async Task<Enemy?> DeleteEntity(int id)
    {
        var toDelete = await GetById(id);
        if (toDelete is null) return null;
        _context.Enemies.Remove(toDelete);
        await _context.SaveChangesAsync();
        return toDelete;
    }

    public async Task<List<Enemy>> GetAllEntities()
    {
        return await _context.Enemies.ToListAsync();
    }

    public async Task<Enemy?> GetById(int id)
    {
        return await _context.Enemies.FirstOrDefaultAsync(t => t.EnemyId == id);
    }

    public async Task<Enemy?> UpdateEntity(int id, Dictionary<string, object> updates)
    {
        var originalEnemy = await GetById(id);

        if (originalEnemy != null)
        {
            foreach (var update in updates)
            {
                var property = originalEnemy.GetType().GetProperty(update.Key);
                if (property != null & property.CanWrite)
                {
                    property.SetValue(originalEnemy, update.Value);
                }
            }
            await _context.SaveChangesAsync();
        }
        return null;
    }
}