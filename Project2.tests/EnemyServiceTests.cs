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
    public class EnemyServiceTests
    {
        private readonly Mock<IRepo<Enemy>> _mockEnemyRepo;
        private readonly EnemyService _enemyService;

        public EnemyServiceTests()
        {
            _mockEnemyRepo = new Mock<IRepo<Enemy>>();
            _enemyService = new EnemyService(_mockEnemyRepo.Object);
        }

        [Fact]
        public async Task GetAllEntities_ShouldReturnListOfEnemies()
        {
            // Arrange
            var enemies = new List<Enemy>
            {
                new Enemy { EnemyId = 1, EnemyName = "Orc", Attack = 10, Health = 50, ImageUrl = "http://example.com/orc.png" },
                new Enemy { EnemyId = 2, EnemyName = "Goblin", Attack = 5, Health = 30, ImageUrl = "http://example.com/goblin.png" }
            };
            _mockEnemyRepo.Setup(repo => repo.GetAllEntities()).ReturnsAsync(enemies);

            // Act
            var result = await _enemyService.GetAllEntities();

            // Assert
            Assert.Equal(enemies, result);
        }

        [Fact]
        public async Task GetEntityById_ShouldReturnEnemy_WhenIdIsValid()
        {
            // Arrange
            var enemy = new Enemy { EnemyId = 1, EnemyName = "Orc", Attack = 10, Health = 50, ImageUrl = "http://example.com/orc.png" };
            _mockEnemyRepo.Setup(repo => repo.GetById(1)).ReturnsAsync(enemy);

            // Act
            var result = await _enemyService.GetEntityById(1);

            // Assert
            Assert.Equal(enemy, result);
        }

        [Fact]
        public async Task GetEntityById_ShouldThrowException_WhenIdIsLessThanOne()
        {
            // Act & Assert
            var exception = await Assert.ThrowsAsync<Exception>(() => _enemyService.GetEntityById(0));
            Assert.Equal("Enemy Id cannot be less than 1", exception.Message);
        }

        [Fact]
        public async Task GetEntityById_ShouldReturnNull_WhenEnemyDoesNotExist()
        {
            // Arrange
            _mockEnemyRepo.Setup(repo => repo.GetById(It.IsAny<int>())).ReturnsAsync((Enemy)null);

            // Act
            var result = await _enemyService.GetEntityById(999);

            // Assert
            Assert.Null(result);
        }
    }
}
