using Microsoft.EntityFrameworkCore;
using Project2.app.DataAccess.Interfaces;
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

    public async Task<Spell?> DeleteEntity(int id)
    {
        var toDelete = await GetById(id);
        if (toDelete is null) return null;
        _context.Spells.Remove(toDelete);
        await _context.SaveChangesAsync();
        return toDelete;
    }

    public async Task<List<Spell>> GetAllEntities()
    {
        return await _context.Spells.ToListAsync();
    }

    public async Task<Spell?> GetById(int id)
    {
        return await _context.Spells.FirstOrDefaultAsync(t => t.SpellId == id);
    }

    public async Task<Spell?> UpdateEntity(int id, Dictionary<string, object> updates)
    {
        var originalSpell = await GetById(id);

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
            await _context.SaveChangesAsync();
        }
        return null;
    }
}