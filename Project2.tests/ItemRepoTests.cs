/*
using Microsoft.EntityFrameworkCore;
using Project2.app.DataAccess;
using Project2.app.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Project2.Tests
{
    public class ItemRepoTests
    {
        private readonly ItemRepo _repo;
        private readonly DbContextOptions<ApplicationDbContext> _options;

        public ItemRepoTests()
        {
            _options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;

            using (var context = new ApplicationDbContext(_options))
            {
                _repo = new ItemRepo(context);
                SeedDatabase(context);
            }
        }

        private void SeedDatabase(ApplicationDbContext context)
        {
            context.Items.Add(new Item { ItemId = 1, ItemName = "Sword", Attack = 10, ImageUrl = "sword.png" });
            context.Items.Add(new Item { ItemId = 2, ItemName = "Shield", Attack = 5, ImageUrl = "shield.png" });
            context.SaveChanges();
        }

        [Fact]
        public async Task CreateEntity_ShouldAddItemToDatabase()
        {
            // Arrange
            var newItem = new Item { ItemId = 3, ItemName = "Helmet", Attack = 3, ImageUrl = "helmet.png" };

            // Act
            var result = await _repo.CreateEntity(newItem);

            // Assert
            using (var context = new ApplicationDbContext(_options))
            {
                var item = await context.Items.FindAsync(result.ItemId);
                Assert.NotNull(item);
                Assert.Equal("Helmet", item.ItemName);
            }
        }

        [Fact]
        public async Task GetAllEntities_ShouldReturnAllItems()
        {
            // Act
            var result = await _repo.GetAllEntities();

            // Assert
            Assert.Equal(2, result.Count); // Adjust count based on your seed data
        }

        [Fact]
        public async Task GetById_ShouldReturnItemWithMatchingId()
        {
            // Act
            var result = await _repo.GetById(1);

            // Assert
            Assert.NotNull(result);
            Assert.Equal("Sword", result.ItemName);
        }

        [Fact]
        public async Task DeleteEntity_ShouldRemoveItemFromDatabase()
        {
            // Act
            var result = await _repo.DeleteEntity(1);

            // Assert
            Assert.NotNull(result);
            Assert.Equal("Sword", result.ItemName);

            using (var context = new ApplicationDbContext(_options))
            {
                var item = await context.Items.FindAsync(1);
                Assert.Null(item);
            }
        }

        [Fact]
        public async Task UpdateEntity_ShouldUpdateItemAndSaveChanges()
        {
            // Arrange
            var updates = new Dictionary<string, object> { { "ItemName", "Updated Sword" } };

            // Act
            var result = await _repo.UpdateEntity(1, updates);

            // Assert
            using (var context = new ApplicationDbContext(_options))
            {
                var item = await context.Items.FindAsync(1);
                Assert.NotNull(item);
                Assert.Equal("Updated Sword", item.ItemName);
            }
        }
    }
}
*/