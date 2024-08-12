using Microsoft.EntityFrameworkCore;
using Project2.app.DataAccess;
using Project2.app.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace Project2.tests
{
    public class EnemyRepoTests
    {
        private async Task<ApplicationDbContext> GetInMemoryDbContext(string databaseName)
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: databaseName)
                .Options;

            var context = new ApplicationDbContext(options);

            // Clear existing data to ensure a clean state
            context.Enemies.RemoveRange(context.Enemies);
            await context.SaveChangesAsync();

            // Seed the database with test data
            context.Enemies.AddRange(new List<Enemy>
            {
                new Enemy { EnemyId = 1, EnemyName = "Tester1", Attack = 5, Health = 30, ImageUrl = "url1" },
                new Enemy { EnemyId = 2, EnemyName = "Tester2", Attack = 10, Health = 50, ImageUrl = "url2" }
            });
            await context.SaveChangesAsync();

            return context;
        }

        [Fact]
        public async Task CreateEntity_ShouldAddEnemy()
        {
            var context = await GetInMemoryDbContext("TestDb_CreateEntity");
            var repo = new EnemyRepo(context);
            var newEnemy = new Enemy { EnemyId = 3, EnemyName = "Tester3", Attack = 15, Health = 80, ImageUrl = "url3" };

            var result = await repo.CreateEntity(newEnemy);
            var createdEnemy = await context.Enemies.FindAsync(3);

            Assert.NotNull(createdEnemy);
            Assert.Equal("Tester3", createdEnemy.EnemyName);
        }

        [Fact]
        public async Task DeleteEntity_ShouldRemoveEnemy()
        {
            var context = await GetInMemoryDbContext("TestDb_DeleteEntity");
            var repo = new EnemyRepo(context);

            var result = await repo.DeleteEntity(1);
            var deletedEnemy = await context.Enemies.FindAsync(1);

            Assert.NotNull(result);
            Assert.Null(deletedEnemy);
        }

        [Fact]
        public async Task GetAllEntities_ShouldReturnAllEnemies()
        {
            var context = await GetInMemoryDbContext("TestDb_GetAllEntities");
            var repo = new EnemyRepo(context);

            var result = await repo.GetAllEntities();

            Assert.Equal(2, result.Count);
        }

        [Fact]
        public async Task GetById_ShouldReturnCorrectEnemy()
        {
            var context = await GetInMemoryDbContext("TestDb_GetById");
            var repo = new EnemyRepo(context);

            var result = await repo.GetById(1);

            Assert.NotNull(result);
            Assert.Equal("Tester1", result.EnemyName);
        }

        [Fact]
        public async Task UpdateEntity_ShouldModifyEnemy()
        {
            var context = await GetInMemoryDbContext("TestDb_UpdateEntity");
            var repo = new EnemyRepo(context);
            var updates = new Dictionary<string, object>
            {
                { "Health", 100 }
            };

            var result = await repo.UpdateEntity(1, updates);
            var updatedEnemy = await context.Enemies.FindAsync(1);

            Assert.NotNull(updatedEnemy);
            Assert.Equal(100, updatedEnemy.Health);
        }
    }
}
