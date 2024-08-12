/*
using Microsoft.EntityFrameworkCore;
using Project2.app.DataAccess;
using Project2.app.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace Project2.Tests
{
    public class PlayerRepoTests
    {
        private readonly PlayerRepo _repo;
        private readonly DbContextOptions<ApplicationDbContext> _options;

        public PlayerRepoTests()
        {
            _options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;

            using (var context = new ApplicationDbContext(_options))
            {
                _repo = new PlayerRepo(context);
                SeedDatabase(context);
            }
        }

        private void SeedDatabase(ApplicationDbContext context)
        {
            context.Players.Add(new Player { PlayerId = 100, Name = "Hero", CurrentHealth = 100, CurrentMana = 50, CurrentRoom = 1, CurrentEnemyHealth = 80 });
            context.Players.Add(new Player { PlayerId = 200, Name = "Villain", CurrentHealth = 75, CurrentMana = 30, CurrentRoom = 2, CurrentEnemyHealth = 60 });
            context.SaveChanges();
        }

        [Fact]
        public async Task CreateEntity_ShouldAddPlayerToDatabase()
        {
            // Arrange
            var newPlayer = new Player { PlayerId = 3, Name = "Sidekick", CurrentHealth = 50, CurrentMana = 25, CurrentRoom = 3, CurrentEnemyHealth = 40 };

            // Act
            var result = await _repo.CreateEntity(newPlayer);

            // Assert
            using (var context = new ApplicationDbContext(_options))
            {
                var player = await context.Players.FindAsync(result.PlayerId);
                Assert.NotNull(player);
                Assert.Equal(newPlayer.Name, player.Name);
                Assert.Equal(newPlayer.CurrentHealth, player.CurrentHealth);
                Assert.Equal(newPlayer.CurrentMana, player.CurrentMana);
                Assert.Equal(newPlayer.CurrentRoom, player.CurrentRoom);
                Assert.Equal(newPlayer.CurrentEnemyHealth, player.CurrentEnemyHealth);
            }
        }

        [Fact]
        public async Task GetAllEntities_ShouldReturnAllPlayers()
        {
            // Act
            var players = await _repo.GetAllEntities();

            // Assert
            Assert.Equal(2, players.Count); // There should be 2 players in the seed data
        }

        [Fact]
        public async Task GetById_ShouldReturnPlayerWithMatchingId()
        {
            // Act
            var player = await _repo.GetById(1);

            // Assert
            Assert.NotNull(player);
            Assert.Equal(1, player.PlayerId);
        }

        [Fact]
        public async Task DeleteEntity_ShouldRemovePlayerFromDatabase()
        {
            // Act
            var playerToDelete = await _repo.DeleteEntity(1);

            // Assert
            Assert.NotNull(playerToDelete);
            using (var context = new ApplicationDbContext(_options))
            {
                var deletedPlayer = await context.Players.FindAsync(1);
                Assert.Null(deletedPlayer);
            }
        }

        [Fact]
        public async Task UpdateEntity_ShouldUpdatePlayerAndSaveChanges()
        {
            // Arrange
            var updates = new Dictionary<string, object>
            {
                {"CurrentHealth", 90},
                {"CurrentMana", 60}
            };

            // Act
            var updatedPlayer = await _repo.UpdateEntity(1, updates);

            // Assert
            using (var context = new ApplicationDbContext(_options))
            {
                var player = await context.Players.FindAsync(1);
                Assert.Equal(90, player.CurrentHealth);
                Assert.Equal(60, player.CurrentMana);
            }
        }
    }
}

*/