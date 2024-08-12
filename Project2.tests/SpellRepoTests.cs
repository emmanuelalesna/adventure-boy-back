/*
using Microsoft.EntityFrameworkCore;
using Project2.app.DataAccess;
using Project2.app.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace Project2.Tests
{
    public class SpellRepoTests
    {
        private readonly SpellRepo _spellRepo;
        private readonly ApplicationDbContext _context;

        public SpellRepoTests()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;

            _context = new ApplicationDbContext(options);
            _spellRepo = new SpellRepo(_context);
            SeedDatabase();
        }

        private void SeedDatabase()
        {
            var spells = new List<Spell>
            {
                new Spell { SpellId = 1, SpellName = "Fireball", Attack = 50, ManaCost = 10, ImageUrl = "fireball.png" },
                new Spell { SpellId = 2, SpellName = "Ice Shard", Attack = 30, ManaCost = 5, ImageUrl = "ice_shard.png" }
            };

            _context.Spells.AddRange(spells);
            _context.SaveChanges();
        }

        [Fact]
        public async Task CreateEntity_ShouldAddSpellToDatabase()
        {
            var newSpell = new Spell { SpellId = 3, SpellName = "Lightning Bolt", Attack = 70, ManaCost = 15, ImageUrl = "lightning_bolt.png" };

            var result = await _spellRepo.CreateEntity(newSpell);

            var createdSpell = await _spellRepo.GetById(3);
            Assert.NotNull(createdSpell);
            Assert.Equal("Lightning Bolt", createdSpell?.SpellName);
        }

        [Fact]
        public async Task GetAllEntities_ShouldReturnAllSpells()
        {
            var spells = await _spellRepo.GetAllEntities();

            Assert.Equal(2, spells.Count);
        }

        [Fact]
        public async Task GetById_ShouldReturnSpellWithMatchingId()
        {
            var spell = await _spellRepo.GetById(1);

            Assert.NotNull(spell);
            Assert.Equal("Fireball", spell?.SpellName);
        }

        [Fact]
        public async Task UpdateEntity_ShouldUpdateSpellAndSaveChanges()
        {
            var updates = new Dictionary<string, object>
            {
                { "SpellName", "Firestorm" },
                { "Attack", 100 }
            };

            var result = await _spellRepo.UpdateEntity(1, updates);
            var updatedSpell = await _spellRepo.GetById(1);

            Assert.NotNull(updatedSpell);
            Assert.Equal("Firestorm", updatedSpell?.SpellName);
            Assert.Equal(100, updatedSpell?.Attack);
        }

        [Fact]
        public async Task DeleteEntity_ShouldRemoveSpellFromDatabase()
        {
            var result = await _spellRepo.DeleteEntity(2);

            var deletedSpell = await _spellRepo.GetById(2);

            Assert.NotNull(result);
            Assert.Null(deletedSpell);
        }
    }
}
*/