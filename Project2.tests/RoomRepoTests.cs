using Microsoft.EntityFrameworkCore;
using Project2.app.DataAccess;
using Project2.app.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace Project2.tests
{
    public class RoomRepoTests
    {
        private async Task<ApplicationDbContext> GetInMemoryDbContext(string databaseName)
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: databaseName)
                .Options;

            var context = new ApplicationDbContext(options);

            // Clear existing data to ensure a clean state
            context.Rooms.RemoveRange(context.Rooms);
            await context.SaveChangesAsync();

            // Seed the database with test data
            context.Rooms.AddRange(new List<Room>
            {
                new Room { RoomId = 1, ImageUrl = "image1.png" },
                new Room { RoomId = 2, ImageUrl = "image2.png" }
            });
            await context.SaveChangesAsync();

            return context;
        }

        [Fact]
        public async Task CreateEntity_ShouldAddRoom()
        {
            var context = await GetInMemoryDbContext("TestDb_CreateEntity");
            var repo = new RoomRepo(context);
            var newRoom = new Room { RoomId = 3, ImageUrl = "image3.png" };

            var result = await repo.CreateEntity(newRoom);
            var createdRoom = await context.Rooms.FindAsync(3);

            Assert.NotNull(createdRoom);
            Assert.Equal("image3.png", createdRoom.ImageUrl);
        }

        [Fact]
        public async Task DeleteEntity_ShouldRemoveRoom()
        {
            var context = await GetInMemoryDbContext("TestDb_DeleteEntity");
            var repo = new RoomRepo(context);

            var result = await repo.DeleteEntity(1);
            var deletedRoom = await context.Rooms.FindAsync(1);

            Assert.NotNull(result);
            Assert.Null(deletedRoom);
        }

        [Fact]
        public async Task GetAllEntities_ShouldReturnAllRooms()
        {
            var context = await GetInMemoryDbContext("TestDb_GetAllEntities");
            var repo = new RoomRepo(context);

            var result = await repo.GetAllEntities();

            Assert.Equal(2, result.Count);
        }

        [Fact]
        public async Task GetById_ShouldReturnCorrectRoom()
        {
            var context = await GetInMemoryDbContext("TestDb_GetById");
            var repo = new RoomRepo(context);

            var result = await repo.GetById(1);

            Assert.NotNull(result);
            Assert.Equal("image1.png", result.ImageUrl);
        }

        [Fact]
        public async Task UpdateEntity_ShouldModifyRoom()
        {
            var context = await GetInMemoryDbContext("TestDb_UpdateEntity");
            var repo = new RoomRepo(context);
            var updates = new Dictionary<string, object>
            {
                { "ImageUrl", "updated_image.png" }
            };

            var result = await repo.UpdateEntity(1, updates);
            var updatedRoom = await context.Rooms.FindAsync(1);

            Assert.NotNull(updatedRoom);
            Assert.Equal("updated_image.png", updatedRoom.ImageUrl);
        }
    }
}
