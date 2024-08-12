using Microsoft.EntityFrameworkCore;
using Project2.app.DataAccess;
using Project2.app.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace Project2.tests
{
    public class PlayerRepoTests
    {
        private async Task<ApplicationDbContext> GetInMemoryDbContext(string databaseName)
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: databaseName)
                .Options;

            var context = new ApplicationDbContext(options);

            // Clear existing data to ensure a clean state
            context.Players.RemoveRange(context.Players);
            await context.SaveChangesAsync();

            // Seed the database with test data
            context.Players.AddRange(new List<Player>
            {
                new Player { PlayerId = 1, Name = "Player1", CurrentHealth = 100, CurrentMana = 50, CurrentRoom = 1, CurrentEnemyHealth = 75 },
                new Player { PlayerId = 2, Name = "Player2", CurrentHealth = 80, CurrentMana = 40, CurrentRoom = 2, CurrentEnemyHealth = 60 }
            });
            await context.SaveChangesAsync();

            return context;
        }

        [Fact]
        public async Task CreateEntity_ShouldAddPlayer()
        {
            var context = await GetInMemoryDbContext("TestDb_CreateEntity");
            var repo = new PlayerRepo(context);
            var newPlayer = new Player { PlayerId = 3, Name = "Player3", CurrentHealth = 90, CurrentMana = 45, CurrentRoom = 3, CurrentEnemyHealth = 70 };

            var result = await repo.CreateEntity(newPlayer);
            var createdPlayer = await context.Players.FindAsync(3);

            Assert.NotNull(createdPlayer);
            Assert.Equal("Player3", createdPlayer.Name);
            Assert.Equal(90, createdPlayer.CurrentHealth);
        }

        [Fact]
        public async Task DeleteEntity_ShouldRemovePlayer()
        {
            var context = await GetInMemoryDbContext("TestDb_DeleteEntity");
            var repo = new PlayerRepo(context);

            var result = await repo.DeleteEntity(1);
            var deletedPlayer = await context.Players.FindAsync(1);

            Assert.NotNull(result);
            Assert.Null(deletedPlayer);
        }

        [Fact]
        public async Task GetAllEntities_ShouldReturnAllPlayers()
        {
            var context = await GetInMemoryDbContext("TestDb_GetAllEntities");
            var repo = new PlayerRepo(context);

            var result = await repo.GetAllEntities();

            Assert.Equal(2, result.Count);
        }

        [Fact]
        public async Task GetById_ShouldReturnCorrectPlayer()
        {
            var context = await GetInMemoryDbContext("TestDb_GetById");
            var repo = new PlayerRepo(context);

            var result = await repo.GetById(1);

            Assert.NotNull(result);
            Assert.Equal("Player1", result.Name);
        }

        [Fact]
        public async Task UpdateEntity_ShouldModifyPlayer()
        {
            var context = await GetInMemoryDbContext("TestDb_UpdateEntity");
            var repo = new PlayerRepo(context);
            var updates = new Dictionary<string, object>
            {
                { "CurrentHealth", 120 },
                { "CurrentRoom", 5 }
            };

            var result = await repo.UpdateEntity(1, updates);
            var updatedPlayer = await context.Players.FindAsync(1);

            Assert.NotNull(updatedPlayer);
            Assert.Equal(120, updatedPlayer.CurrentHealth);
            Assert.Equal(5, updatedPlayer.CurrentRoom);
        }
    }
}
