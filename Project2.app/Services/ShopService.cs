using Project2.app.DataAccess;
using Project2.app.Models;
using Project2.app.Services.Interface;

namespace Project2.app.Services;

public class ShopService(IRepo<Shop> IShopRepo) : IService<Shop>
{

    private readonly IRepo<Shop> _ShopRepo = IShopRepo;
    public Task<Shop> CreateNewEntity(Shop entityToCreate)
    {
        throw new NotImplementedException();
    }

    public Task<Shop?> DeleteEntity(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<List<Shop>> GetAllEntities()
    {
        return await _ShopRepo.GetAllEntities();
    }

    public async Task<Shop?> GetEntityById(int id)
    {
        if (id < 1) throw new Exception("Spell Id cannot be less than 1");
        return await _ShopRepo.GetById(id);
    }

    public Task<Shop?> UpdateEntity(int id, Dictionary<string, object> updates)
    {
        throw new NotImplementedException();
    }
}