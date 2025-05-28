using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Project2.app.DataAccess.Interfaces;
using Project2.app.Models;

namespace Project2.app.DataAccess;

public class PlayerRepo(ApplicationDbContext context) : IPlayerRepo
{

    private readonly ApplicationDbContext _context = context;

    public async Task<Player> CreateEntity(Player player)
    {
        _context.Players.Add(player);
        await _context.SaveChangesAsync();
        return player;
    }

    public async Task<Player?> DeleteEntity(int id)
    {
        var toDelete = await GetById(id);
        if (toDelete is null) return null;
        _context.Players.Remove(toDelete);
        await _context.SaveChangesAsync();
        return toDelete;
    }

    public async Task<List<Player>> GetAllEntities()
    {
        return await _context.Players.ToListAsync();
    }

    public async Task<List<Player>> GetAllEntities(string id)
    {
        return await _context.Players.Where(i => i.AccountId == id).ToListAsync();
    }

    public async Task<Player?> GetById(int id)
    {
        return await _context.Players.FirstOrDefaultAsync(p => p.PlayerId == id);
    }

    public async Task<Player?> GetById(string account, int id)
    {
        return await _context.Players.Where(i => i.AccountId == account).FirstOrDefaultAsync(p => p.PlayerId == id);
    }

    public async Task<Player?> UpdateEntity(int id, Dictionary<string, object> updates)
    {
        var originalPlayer = await GetById(id);

        if (originalPlayer != null)
        {
            foreach (var update in updates)
            {
                var property = originalPlayer.GetType().GetProperty(update.Key);
                if (property != null && property.CanWrite)
                {
                    property.SetValue(originalPlayer, update.Value);
                }

            }
            await _context.SaveChangesAsync();
        }
        return originalPlayer;
    }
    //  var updatesPlayer = new Dictionary<string, object>
    //                 {
    //                     {"CurrentRoom", 0},
    //                     {"Health", 5},
    //                 };
    //                 playerService.UpdateFields(updatesPlayer);
}