using Project2.app.Models;
using Microsoft.EntityFrameworkCore;

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

    public async Task<Room> DeleteEntity(int id)
    {
        Room toDelete = _context.Rooms.Find(id);
        _context.Players.Remove(toDelete);
        await _context.SaveChangesAsync();
        return toDelete;
    }

    public async Task<List<Room>> GetAllEntities()
    {
        return await _context.Rooms
            .ToListAsync();
    }

    public async Task<Room> GetById(int id)
    {
        return await _context.Rooms
            .FirstOrDefaultAsync(r => r.RoomId == id);
    }

    public async Task<Room> UpdateEntity(int id, Dictionary<string, object> updates)
    {
        Room originalRoom = _context.Rooms.FirstOrDefault(r => r.RoomId == id);

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
        }
        await _context.SaveChangesAsync();
        return originalRoom;
    }
}