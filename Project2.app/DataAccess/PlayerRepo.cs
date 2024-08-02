using Microsoft.EntityFrameworkCore;
using Project2.app.Models;

namespace Project2.app.DataAccess;

public class PlayerRepo(ApplicationDbContext context) : IRepo<Player>
{

    private readonly ApplicationDbContext _context = context;

    public async Task<Player> CreateEntity(Player player)
    {
        _context.Players.Add(player);
        await _context.SaveChangesAsync();
        return player;
    }

    public async Task<Player> DeleteEntity(int id)
    {
        Player toDelete = _context.Players.Find(id);
        _context.Players.Remove(toDelete);
        await _context.SaveChangesAsync();
        return toDelete;
    }

    public async Task<List<Player>> GetAllEntities()
    {
        return await _context.Players
            .Include(p => p.Spells)
            .ToListAsync();
    }

    public async Task<Player> GetById(int id)
    {
        return await _context.Players
            .Include(t => t.Spells)
            .FirstOrDefaultAsync(t => t.PlayerId == id);
    }

    public async Task<Player> UpdateEntity(int id, Dictionary<string, object> updates)
    {
        Player originalPlayer = _context.Players.FirstOrDefault(p => p.PlayerId == id);

        if (originalPlayer != null)
        {
            foreach (var update in updates)
            {
                var property = originalPlayer.GetType().GetProperty(update.Key);
                if (property != null & property.CanWrite)
                {
                    property.SetValue(originalPlayer, update.Value);
                }

            }
        }
        await _context.SaveChangesAsync();
        return originalPlayer;
    }
}