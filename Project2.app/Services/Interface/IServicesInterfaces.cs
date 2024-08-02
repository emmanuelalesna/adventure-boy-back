using Project2.app.Models;

namespace Project2.app.DataAccess;

public interface IService<Type>
{
    Task<Type> CreateNewEntity(Type entityToCreate);

    Task<Type> DeleteNewEntity(Type entityToDelete);

    Task<Type> UpdateNewEntity(int id, Dictionary<string, object> updates);

    Task<Type> GetEntityByI(int id);

    Task<List<Type>> GetAllEntities();

}
