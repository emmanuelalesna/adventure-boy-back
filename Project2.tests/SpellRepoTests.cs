using Microsoft.EntityFrameworkCore;
using Project2.app.DataAccess;
using Project2.app.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace Project2.tests
{
    public class SpellRepoTests
    {
        private async Task<ApplicationDbContext> GetInMemoryDbContext(string databaseName)
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: databaseName)
                .Options;

            var context = new ApplicationDbContext(options);

            // Clear existing data to ensure a clean state
            context.Spells.RemoveRange(context.Spells);
            await context.SaveChangesAsync();

            // Seed the database with test data
            context.Spells.AddRange(new List<Spell>
            {
                new Spell { SpellId = 1, SpellName = "Fireball", Attack = 50, ManaCost = 10, ImageUrl = "fireball.png" },
                new Spell { SpellId = 2, SpellName = "Ice Blast", Attack = 30, ManaCost = 8, ImageUrl = "iceblast.png" }
            });
            await context.SaveChangesAsync();

            return context;
        }

        [Fact]
        public async Task CreateEntity_ShouldAddSpell()
        {
            var context = await GetInMemoryDbContext("TestDb_CreateEntity");
            var repo = new SpellRepo(context);
            var newSpell = new Spell { SpellId = 3, SpellName = "Lightning Bolt", Attack = 40, ManaCost = 12, ImageUrl = "lightningbolt.png" };

            var result = await repo.CreateEntity(newSpell);
            var createdSpell = await context.Spells.FindAsync(3);

            Assert.NotNull(createdSpell);
            Assert.Equal("Lightning Bolt", createdSpell.SpellName);
            Assert.Equal(40, createdSpell.Attack);
        }

        [Fact]
        public async Task DeleteEntity_ShouldRemoveSpell()
        {
            var context = await GetInMemoryDbContext("TestDb_DeleteEntity");
            var repo = new SpellRepo(context);

            var result = await repo.DeleteEntity(1);
            var deletedSpell = await context.Spells.FindAsync(1);

            Assert.NotNull(result);
            Assert.Null(deletedSpell);
        }

        [Fact]
        public async Task GetAllEntities_ShouldReturnAllSpells()
        {
            var context = await GetInMemoryDbContext("TestDb_GetAllEntities");
            var repo = new SpellRepo(context);

            var result = await repo.GetAllEntities();

            Assert.Equal(2, result.Count);
        }

        [Fact]
        public async Task GetById_ShouldReturnCorrectSpell()
        {
            var context = await GetInMemoryDbContext("TestDb_GetById");
            var repo = new SpellRepo(context);

            var result = await repo.GetById(1);

            Assert.NotNull(result);
            Assert.Equal("Fireball", result.SpellName);
        }

        [Fact]
        public async Task UpdateEntity_ShouldModifySpell()
        {
            var context = await GetInMemoryDbContext("TestDb_UpdateEntity");
            var repo = new SpellRepo(context);
            var updates = new Dictionary<string, object>
            {
                { "Attack", 60 },
                { "ManaCost", 15 }
            };

            var result = await repo.UpdateEntity(1, updates);
            var updatedSpell = await context.Spells.FindAsync(1);

            Assert.NotNull(updatedSpell);
            Assert.Equal(60, updatedSpell.Attack);
            Assert.Equal(15, updatedSpell.ManaCost);
        }
    }
}
