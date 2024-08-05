namespace Project2.app.Services.Interface;

public interface IService<Type>
{
    Task<Type> CreateNewEntity(Type entityToCreate);

    Task<Type?> DeleteEntity(int id);

    Task<Type?> UpdateEntity(int id, Dictionary<string, object> updates);

    Task<Type?> GetEntityById(int id);

    Task<List<Type>> GetAllEntities();

}
