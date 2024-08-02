namespace Project2.app.DataAccess;

public interface IRepo<Type>
{
    Task<Type> CreateEntity(Type entity);
    Task<Type> GetById(int id);
    Task<List<Type>> GetAllEntities();
    Task<Type> UpdateEntity(int id, Dictionary<string, object> updates);
    Task<Type> DeleteEntity(int id);
}