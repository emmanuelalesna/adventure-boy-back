using Project2.app.Models;
using Microsoft.EntityFrameworkCore;
using Project2.app.DataAccess.Interfaces;

namespace Project2.app.DataAccess;

public class RoomRepo(ApplicationDbContext context) : IRepo<Room>
{
    private readonly ApplicationDbContext _context = context;

    public async Task<Room> CreateEntity(Room room)
    {
        _context.Rooms.Add(room);
        await _context.SaveChangesAsync();
        return room;
    }

    public async Task<Room?> DeleteEntity(int id)
    {
        var toDelete = await GetById(id);
        if (toDelete is null) return null;
        _context.Rooms.Remove(toDelete);
        await _context.SaveChangesAsync();
        return toDelete;
    }

    public async Task<List<Room>> GetAllEntities()
    {
        return await _context.Rooms.ToListAsync();
    }

    public async Task<Room?> GetById(int id)
    {
        return await _context.Rooms.FirstOrDefaultAsync(t => t.RoomId == id);
    }

    public async Task<Room?> UpdateEntity(int id, Dictionary<string, object> updates)
    {
        var originalRoom = await GetById(id);

        if (originalRoom != null)
        {
            foreach (var update in updates)
            {
                var property = originalRoom.GetType().GetProperty(update.Key);
                if (property != null & property.CanWrite)
                {
                    property.SetValue(originalRoom, update.Value);
                }

            }
            await _context.SaveChangesAsync();
        }
        return null;
    }
}