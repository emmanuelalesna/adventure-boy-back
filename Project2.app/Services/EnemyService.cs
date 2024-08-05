using Project2.app.DataAccess;
using Project2.app.Models;
using Project2.app.Services.Interface;

namespace Project2.app.Services;

public class EnemyService(IRepo<Enemy> IEnemyRepo) : IService<Enemy>
{

    private readonly IRepo<Enemy> _EnemyRepo = IEnemyRepo;
    public Task<Enemy> CreateNewEntity(Enemy entityToCreate)
    {
        throw new NotImplementedException();
    }

    public Task<Enemy?> DeleteEntity(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<List<Enemy>> GetAllEntities()
    {
        return await _EnemyRepo.GetAllEntities();
    }

    public async Task<Enemy?> GetEntityById(int id)
    {
        if (id < 1 || id == null) throw new Exception("Enemy Id cannot be less than 1");
        return await _EnemyRepo.GetById(id);
    }

    public Task<Enemy?> UpdateEntity(int id, Dictionary<string, object> updates)
    {
        throw new NotImplementedException();
    }
}