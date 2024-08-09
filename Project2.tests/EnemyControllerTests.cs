using Microsoft.AspNetCore.Mvc;
using Moq;
using Project2.app.Controllers;
using Project2.app.Models;
using Project2.app.Services.Interface;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace Project2.Tests
{
    public class EnemyControllerTests
    {
        private readonly Mock<IService<Enemy>> _mockEnemyService;
        private readonly EnemyController _controller;

        public EnemyControllerTests()
        {
            _mockEnemyService = new Mock<IService<Enemy>>();
            _controller = new EnemyController(_mockEnemyService.Object);
        }

        [Fact]
        public async Task GetAllEnemies_ReturnsOkResult_WithListOfEnemies()
        {
            // Arrange
            var enemies = new List<Enemy>
            {
                new Enemy { EnemyId = 1, EnemyName = "Enemy1", Attack = 10, Health = 100, ImageUrl = "http://example.com/image1" },
                new Enemy { EnemyId = 2, EnemyName = "Enemy2", Attack = 20, Health = 200, ImageUrl = "http://example.com/image2" }
            };
            _mockEnemyService.Setup(service => service.GetAllEntities()).ReturnsAsync(enemies);

            // Act
            var result = await _controller.GetAllEnemies();

            // Assert
            var actionResult = Assert.IsType<OkObjectResult>(result);
            var returnEnemies = Assert.IsType<List<Enemy>>(actionResult.Value);
            Assert.Equal(2, returnEnemies.Count);
        }

        [Fact]
        public async Task GetEnemyById_ReturnsOkResult_WithEnemy()
        {
            // Arrange
            var enemy = new Enemy { EnemyId = 1, EnemyName = "Enemy1", Attack = 10, Health = 100, ImageUrl = "http://example.com/image1" };
            _mockEnemyService.Setup(service => service.GetEntityById(1)).ReturnsAsync(enemy);

            // Act
            var result = await _controller.GetEnemyById(1);

            // Assert
            var actionResult = Assert.IsType<OkObjectResult>(result);
            var returnEnemy = Assert.IsType<Enemy>(actionResult.Value);
            Assert.Equal("Enemy1", returnEnemy.EnemyName);
            Assert.Equal(10, returnEnemy.Attack);
            Assert.Equal(100, returnEnemy.Health);
            Assert.Equal("http://example.com/image1", returnEnemy.ImageUrl);
        }

        [Fact]
        public async Task GetEnemyById_ReturnsNotFound_WhenEnemyDoesNotExist()
        {
            // Arrange
            _mockEnemyService.Setup(service => service.GetEntityById(1)).ReturnsAsync((Enemy)null);

            // Act
            var result = await _controller.GetEnemyById(1);

            // Assert
            var actionResult = Assert.IsType<NotFoundObjectResult>(result);
            Assert.Equal("Enemy does not exist!", actionResult.Value);
        }

        [Fact]
        public async Task GetEnemyById_ReturnsBadRequest_WhenExceptionIsThrown()
        {
            // Arrange
            _mockEnemyService.Setup(service => service.GetEntityById(It.IsAny<int>())).ThrowsAsync(new Exception("Some error"));

            // Act
            var result = await _controller.GetEnemyById(1);

            // Assert
            var actionResult = Assert.IsType<BadRequestObjectResult>(result);
            Assert.Equal("Some error", actionResult.Value);
        }
    }
}
