using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Project2.app.Models;
using Project2.app.Services.Interface;

namespace Project2.app.Services
{
    public class ItemService(IRepo<Item> itemRepo) : IService<Item>
    {
        private readonly IRepo<Item> _itemRepo = itemRepo;

        public async Task<Item> CreateNewEntity(Item entityToCreate)
        {
            throw new NotImplementedException();
        }

        public async Task<Item?> DeleteEntity(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Item>> GetAllEntities()
        {
            return await _itemRepo.GetAllEntities();
        }

        public async Task<Item?> GetEntityById(int id)
        {
            if (id < 1) throw new Exception("Item Id cannot be less than 1");
            return await _itemRepo.GetById(id);
        }

        public async Task<Item?> UpdateEntity(int id, Dictionary<string, object> updates)
        {
            throw new NotImplementedException();
        }
    }
}
