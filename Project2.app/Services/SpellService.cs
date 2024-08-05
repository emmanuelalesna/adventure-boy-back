using Project2.app.DataAccess;
using Project2.app.Models;
using Project2.app.Services.Interface;

namespace Project2.app.Services;

public class SpellService(IRepo<Spell> ISpellRepo) : IService<Spell>
{

    private readonly IRepo<Spell> _SpellRepo = ISpellRepo;
    public Task<Spell> CreateNewEntity(Spell entityToCreate)
    {
        throw new NotImplementedException();
    }

    public Task<Spell?> DeleteEntity(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<List<Spell>> GetAllEntities()
    {
        return await _SpellRepo.GetAllEntities();
    }

    public async Task<Spell?> GetEntityById(int id)
    {
        if (id < 1) throw new Exception("Spell Id cannot be less than 1");
        return await _SpellRepo.GetById(id);
    }

    public Task<Spell?> UpdateEntity(int id, Dictionary<string, object> updates)
    {
        throw new NotImplementedException();
    }
}