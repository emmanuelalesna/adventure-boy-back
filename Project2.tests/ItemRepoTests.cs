using Microsoft.EntityFrameworkCore;
using Project2.app.DataAccess;
using Project2.app.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace Project2.tests
{
    public class ItemRepoTests
    {
        private async Task<ApplicationDbContext> GetInMemoryDbContext(string databaseName)
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: databaseName)
                .Options;

            var context = new ApplicationDbContext(options);

            // Clear existing data to ensure a clean state
            context.Items.RemoveRange(context.Items);
            await context.SaveChangesAsync();

            // Seed the database with test data
            context.Items.AddRange(new List<Item>
            {
                new Item { ItemId = 1, ItemName = "Testing1", Attack = 10, ImageUrl = "testing1.png" },
                new Item { ItemId = 2, ItemName = "Testing2", Attack = 5, ImageUrl = "testing2.png" }
            });
            await context.SaveChangesAsync();

            return context;
        }

        [Fact]
        public async Task CreateEntity_ShouldAddItem()
        {
            var context = await GetInMemoryDbContext("TestDb_CreateEntity");
            var repo = new ItemRepo(context);
            var newItem = new Item { ItemId = 3, ItemName = "Testing3", Attack = 20, ImageUrl = "testing3.png" };

            var result = await repo.CreateEntity(newItem);
            var createdItem = await context.Items.FindAsync(3);

            Assert.NotNull(createdItem);
            Assert.Equal("Testing3", createdItem.ItemName);
        }

        [Fact]
        public async Task DeleteEntity_ShouldRemoveItem()
        {
            var context = await GetInMemoryDbContext("TestDb_DeleteEntity");
            var repo = new ItemRepo(context);

            var result = await repo.DeleteEntity(1);
            var deletedItem = await context.Items.FindAsync(1);

            Assert.NotNull(result);
            Assert.Null(deletedItem);
        }

        [Fact]
        public async Task GetAllEntities_ShouldReturnAllItems()
        {
            var context = await GetInMemoryDbContext("TestDb_GetAllEntities");
            var repo = new ItemRepo(context);

            var result = await repo.GetAllEntities();

            Assert.Equal(2, result.Count);
        }

        [Fact]
        public async Task GetById_ShouldReturnCorrectItem()
        {
            var context = await GetInMemoryDbContext("TestDb_GetById");
            var repo = new ItemRepo(context);

            var result = await repo.GetById(1);

            Assert.NotNull(result);
            Assert.Equal("Testing1", result.ItemName);
        }

        [Fact]
        public async Task UpdateEntity_ShouldModifyItem()
        {
            var context = await GetInMemoryDbContext("TestDb_UpdateEntity");
            var repo = new ItemRepo(context);
            var updates = new Dictionary<string, object>
            {
                { "Attack", 25 }
            };

            var result = await repo.UpdateEntity(1, updates);
            var updatedItem = await context.Items.FindAsync(1);

            Assert.NotNull(updatedItem);
            Assert.Equal(25, updatedItem.Attack);
        }
    }
}
