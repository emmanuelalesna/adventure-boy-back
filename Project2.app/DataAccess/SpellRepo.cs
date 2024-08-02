using Microsoft.EntityFrameworkCore;
using Project2.app.Models;

namespace Project2.app.DataAccess;

public class SpellRepo(ApplicationDbContext context) : IRepo<Spell>
{

    private readonly ApplicationDbContext _context = context;

    public async Task<Spell> CreateEntity(Spell spell)
    {
        _context.Spells.Add(spell);
        await _context.SaveChangesAsync();
        return spell;
    }

    public async Task<Spell> DeleteEntity(int id)
    {
        Spell toDelete = _context.Spells.Find(id);
        _context.Spells.Remove(toDelete);
        await _context.SaveChangesAsync();
        return toDelete;
    }

    public async Task<List<Spell>> GetAllEntities()
    {
        return await _context.Spells.ToListAsync();
    }

    public async Task<Spell> GetById(int id)
    {
        return await _context.Spells.FirstOrDefaultAsync(t => t.SpellId == id);
    }

    /* public Task<Player> UpdateEntity(int id, Player updatePlayer)
    {
        Player oldPlayer = _context.Players.Find(id)!;
        oldPlayer.Health = updateTrainer.Username;
        oldPlayer.Level = updateTrainer.Password;
        await _context.SaveChangesAsync();
        return oldTrainer;
    } */
    public async Task<Spell> UpdateEntity(int id, Dictionary<string, object> updates)
    {
        Spell originalSpell = _context.Spells.FirstOrDefault(p => p.SpellId == id);

        if (originalSpell != null)
        {
            foreach (var update in updates)
            {
                var property = originalSpell.GetType().GetProperty(update.Key);
                if (property != null & property.CanWrite)
                {
                    property.SetValue(originalSpell, update.Value);
                }

            }
        }
        await _context.SaveChangesAsync();
        return originalSpell;
    }
}