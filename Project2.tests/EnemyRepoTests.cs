
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
    public class EnemyRepoTests
    {
        private readonly EnemyRepo _repo;
        private readonly ApplicationDbContext _context;

        public EnemyRepoTests()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;

            _context = new ApplicationDbContext(options);
            _repo = new EnemyRepo(_context);

            // Clear the database and seed with test data
            SeedDatabase();
        }

        private void SeedDatabase()
        {
            _context.Enemies.AddRange(
                new Enemy { EnemyId = 101, EnemyName = "Test1", Attack = 10, Health = 20, ImageUrl = "test1.png" },
                new Enemy { EnemyId = 201, EnemyName = "Test2", Attack = 20, Health = 40, ImageUrl = "test2.png" }
            );
            _context.SaveChanges();
        }

        [Fact]
        public async Task GetAllEntities_ShouldReturnAllEnemies()
        {
            // Act
            var result = await _repo.GetAllEntities();

            // Assert
            Assert.Equal(2, result.Count);
            Assert.Contains(result, e => e.EnemyName == "Test1");
            Assert.Contains(result, e => e.EnemyName == "Test2");
        }

        [Fact]
        public async Task GetById_ShouldReturnEnemyWithMatchingId()
        {
            // Act
            var result = await _repo.GetById(1);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(1, result?.EnemyId);
            Assert.Equal("Test1", result?.EnemyName);
        }

        [Fact]
        public async Task CreateEntity_ShouldAddEnemyToDatabase()
        {
            // Arrange
            var newEnemy = new Enemy { EnemyId = 3, EnemyName = "Test3", Attack = 30, Health = 60, ImageUrl = "test3.png" };

            // Act
            var result = await _repo.CreateEntity(newEnemy);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(3, result.EnemyId);
            Assert.Equal("Test3", result.EnemyName);

            var enemyInDb = await _context.Enemies.FindAsync(3);
            Assert.NotNull(enemyInDb);
            Assert.Equal("Test3", enemyInDb?.EnemyName);
        }

        [Fact]
        public async Task UpdateEntity_ShouldUpdateEnemyAndSaveChanges()
        {
            // Arrange
            var updates = new Dictionary<string, object>
            {
                { "EnemyName", "UpdatedTest1" },
                { "Attack", 15 }
            };

            // Act
            var result = await _repo.UpdateEntity(1, updates);

            // Assert
            Assert.NotNull(result);

            var updatedEnemy = await _context.Enemies.FindAsync(1);
            Assert.NotNull(updatedEnemy);
            Assert.Equal("UpdatedTest1", updatedEnemy?.EnemyName);
            Assert.Equal(15, updatedEnemy?.Attack);
        }

        [Fact]
        public async Task DeleteEntity_ShouldRemoveEnemyFromDatabase()
        {
            // Act
            var result = await _repo.DeleteEntity(2);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(2, result?.EnemyId);

            var enemyInDb = await _context.Enemies.FindAsync(2);
            Assert.Null(enemyInDb);
        }
    }
}
*/