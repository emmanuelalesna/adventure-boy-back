using Moq;
using Project2.app.DataAccess.Interfaces;
using Project2.app.Models;
using Project2.app.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Xunit;

namespace Project2.Tests.Services
{
    public class PlayerServiceTests
    {
        private readonly Mock<IRepo<Player>> _mockPlayerRepo;
        private readonly PlayerService _playerService;

        public PlayerServiceTests()
        {
            _mockPlayerRepo = new Mock<IRepo<Player>>();
            _playerService = new PlayerService(_mockPlayerRepo.Object);
        }

        [Fact]
        public async Task CreateNewEntity_ShouldReturnPlayer_WhenNameIsNotNull()
        {
            // Arrange
            var player = new Player { PlayerId = 1, Name = "Hero", CurrentHealth = 100 };
            _mockPlayerRepo.Setup(repo => repo.CreateEntity(player)).ReturnsAsync(player);

            // Act
            var result = await _playerService.CreateNewEntity(player);

            // Assert
            Assert.Equal(player, result);
        }

        [Fact]
        public async Task CreateNewEntity_ShouldThrowInvalidDataException_WhenNameIsNull()
        {
            // Arrange
            var player = new Player { PlayerId = 1, Name = null };

            // Act & Assert
            var exception = await Assert.ThrowsAsync<InvalidDataException>(() => _playerService.CreateNewEntity(player));
            Assert.Equal("Name cannot be empty.", exception.Message);
        }

        [Fact]
        public async Task GetAllEntities_ShouldReturnListOfPlayers()
        {
            // Arrange
            var players = new List<Player>
            {
                new Player { PlayerId = 1, Name = "Hero", CurrentHealth = 100 },
                new Player { PlayerId = 2, Name = "Villain", CurrentHealth = 80 }
            };
            _mockPlayerRepo.Setup(repo => repo.GetAllEntities()).ReturnsAsync(players);

            // Act
            var result = await _playerService.GetAllEntities();

            // Assert
            Assert.Equal(players, result);
        }

        [Fact]
        public async Task GetEntityById_ShouldReturnPlayer_WhenIdIsValid()
        {
            // Arrange
            var player = new Player { PlayerId = 1, Name = "Hero", CurrentHealth = 100 };
            _mockPlayerRepo.Setup(repo => repo.GetById(1)).ReturnsAsync(player);

            // Act
            var result = await _playerService.GetEntityById(1);

            // Assert
            Assert.Equal(player, result);
        }

        [Fact]
        public async Task UpdateEntity_ShouldReturnUpdatedPlayer()
        {
            // Arrange
            var player = new Player { PlayerId = 1, Name = "Hero", CurrentHealth = 100 };
            var updates = new Dictionary<string, object> { { "CurrentHealth", 90 } };
            _mockPlayerRepo.Setup(repo => repo.UpdateEntity(1, updates)).ReturnsAsync(player);

            // Act
            var result = await _playerService.UpdateEntity(1, updates);

            // Assert
            Assert.Equal(player, result);
        }

        [Fact]
        public async Task DeleteEntity_ShouldThrowNotImplementedException()
        {
            // Act & Assert
            await Assert.ThrowsAsync<NotImplementedException>(() => _playerService.DeleteEntity(1));
        }
    }
}
