using Moq;
using Project2.app.DataAccess.Interfaces;
using Project2.app.Models;
using Project2.app.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace Project2.Tests.Services
{
    public class SpellServiceTests
    {
        private readonly Mock<IRepo<Spell>> _mockSpellRepo;
        private readonly SpellService _spellService;

        public SpellServiceTests()
        {
            _mockSpellRepo = new Mock<IRepo<Spell>>();
            _spellService = new SpellService(_mockSpellRepo.Object);
        }

        [Fact]
        public async Task GetAllEntities_ShouldReturnListOfSpells()
        {
            // Arrange
            var spells = new List<Spell>
            {
                new Spell { SpellId = 1, SpellName = "Fireball", Attack = 50, ManaCost = 10, ImageUrl = "http://example.com/spell1.png" },
                new Spell { SpellId = 2, SpellName = "Ice Shard", Attack = 30, ManaCost = 5, ImageUrl = "http://example.com/spell2.png" }
            };
            _mockSpellRepo.Setup(repo => repo.GetAllEntities()).ReturnsAsync(spells);

            // Act
            var result = await _spellService.GetAllEntities();

            // Assert
            Assert.Equal(spells, result);
        }

        [Fact]
        public async Task GetEntityById_ShouldReturnSpell_WhenIdIsValid()
        {
            // Arrange
            var spell = new Spell { SpellId = 1, SpellName = "Fireball", Attack = 50, ManaCost = 10, ImageUrl = "http://example.com/spell1.png" };
            _mockSpellRepo.Setup(repo => repo.GetById(1)).ReturnsAsync(spell);

            // Act
            var result = await _spellService.GetEntityById(1);

            // Assert
            Assert.Equal(spell, result);
        }

        [Fact]
        public async Task GetEntityById_ShouldThrowException_WhenIdIsLessThanOne()
        {
            // Act & Assert
            await Assert.ThrowsAsync<Exception>(() => _spellService.GetEntityById(0));
        }

        [Fact]
        public async Task CreateNewEntity_ShouldThrowNotImplementedException()
        {
            // Act & Assert
            await Assert.ThrowsAsync<NotImplementedException>(() => _spellService.CreateNewEntity(new Spell()));
        }

        [Fact]
        public async Task UpdateEntity_ShouldThrowNotImplementedException()
        {
            // Act & Assert
            await Assert.ThrowsAsync<NotImplementedException>(() => _spellService.UpdateEntity(1, new Dictionary<string, object>()));
        }

        [Fact]
        public async Task DeleteEntity_ShouldThrowNotImplementedException()
        {
            // Act & Assert
            await Assert.ThrowsAsync<NotImplementedException>(() => _spellService.DeleteEntity(1));
        }
    }
}
