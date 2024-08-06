using Project2.app.DataAccess.Interfaces;
using Project2.app.Models;
using Project2.app.Services.Interface;

namespace Project2.app.Services;

public class RoomService(IRepo<Room> IRoomRepo) : IService<Room> {

    private readonly IRepo<Room> _RoomRepo = IRoomRepo;

    public Task<Room> CreateNewEntity(Room entityToCreate)
    {
        throw new NotImplementedException();
    }

    public Task<Room?> DeleteEntity(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<List<Room>> GetAllEntities()
    {

        return await _RoomRepo.GetAllEntities();
    }

    public async Task<Room?> GetEntityById(int id)
    {
        return await _RoomRepo.GetById(id);
    }

    public Task<Room?> UpdateEntity(int id, Dictionary<string, object> updates)
    {
        throw new NotImplementedException();
    }

}
