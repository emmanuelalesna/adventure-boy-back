using Project2.app.DataAccess.Interfaces;
using Project2.app.Models;
using Project2.app.Services.Interface;

namespace Project2.app.Services;

public class PlayerService(IPlayerRepo playerRepo) : IPlayerService
{
    private readonly IPlayerRepo _playerRepo = playerRepo;

    public async Task<Player> CreateNewEntity(Player entityToCreate)
    {
        try
        {
            if (entityToCreate.Name != null)
            {
                return await _playerRepo.CreateEntity(entityToCreate);
            }
            else
            {
                throw new InvalidDataException("Name cannot be empty.");
            }
        }
        catch (InvalidDataException e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task<Player?> DeleteEntity(int id)
    {
        return await _playerRepo.DeleteEntity(id);
    }

    public async Task<List<Player>> GetAllEntities()
    {
        return await _playerRepo.GetAllEntities();
    }

    public async Task<List<Player>> GetAllEntities(string id)
    {
        return await _playerRepo.GetAllEntities(id);
    }

    public async Task<Player?> GetEntityById(int id)
    {
        return await _playerRepo.GetById(id);
    }

    public async Task<Player?> GetEntityById(string account, int id)
    {
        return await _playerRepo.GetById(account, id);
    }

    public async Task<Player?> UpdateEntity(int id, Dictionary<string, object> updates)
    {
        return await _playerRepo.UpdateEntity(id, updates);
    }


    /*
    public void UpdateFields(int PlayerID, Dictionary<string, object> updates)
    //will take the playerID, and search for it in the database, then assign originalPlayer to that, then only make updates
    // to ones that had changes made
    {
        Player originalPlayer = _context.Players.FirstOrDefault(p => p.PlayerId == PlayerID);
 
        if (originalPlayer != null)
        {
            foreach (var update in updates)
            {
                var property = originalPlayer.GetType().GetProperty(update.Key);
                if (property != null & property.CanWrite)
                {
                    property.SetValue(originalPlayer, update.Value);
                }
 
            }
        }
        _context.SaveChanges();
 
         example of how to make a change
 
        var dao = new PlayerDAO(context);
 
        updates = new Dictionary<string, object>
        {
            { "FirstName", newFirstNameValue },
            { "Health", newHealthValue }
        }       ;
 
        dao.Update(playerItemsID, updates);
    }
    public void UpdateFields(Dictionary<string, object> updates)
    {
        _playerDAO.UpdateFields(State.currentPlayer.PlayerId, updates);
        var loggedInPlayer = _playerDAO.GetByLoginID(Utility.State.currentLogin.LoginId);
        State.currentPlayer = loggedInPlayer;
    }
    */
}