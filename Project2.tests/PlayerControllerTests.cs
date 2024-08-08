using Xunit;
using Moq;
using Microsoft.AspNetCore.Mvc;
using Project2.app.Controllers;
using Project2.app.Models;
using Project2.app.Services.Interface;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Project2.Tests
{
    public class PlayerControllerTests
    {
        private readonly Mock<IService<Player>> _mockPlayerService;
        private readonly PlayerController _controller;

        public PlayerControllerTests()
        {
            _mockPlayerService = new Mock<IService<Player>>();
            _controller = new PlayerController(_mockPlayerService.Object);
        }

        [Fact]
        public async Task CreatePlayer_ReturnsOkResult_WhenPlayerIsValid()
        {
            // Arrange
            var player = new Player { Name = "Hero", Level = 1, CurrentHealth = 10 };
            _mockPlayerService.Setup(service => service.CreateNewEntity(player)).ReturnsAsync(player);

            // Act
            var result = await _controller.CreatePlayer(player);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(player, okResult.Value);
        }

        [Fact]
        public async Task GetAllPlayers_ReturnsOkResult_WithListOfPlayers()
        {
            // Arrange
            var players = new List<Player> 
            { 
                new Player { PlayerId = 1, Name = "Player1", Level = 1 },
                new Player { PlayerId = 2, Name = "Player2", Level = 2 }
            };
            _mockPlayerService.Setup(service => service.GetAllEntities()).ReturnsAsync(players);

            // Act
            var result = await _controller.GetAllPlayers();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(players, okResult.Value);
        }

        [Fact]
        public async Task GetPlayerById_ReturnsNotFound_WhenPlayerDoesNotExist()
        {
            // Arrange
            int playerId = 1;
            _mockPlayerService.Setup(service => service.GetEntityById(playerId)).ReturnsAsync((Player)null);

            // Act
            var result = await _controller.GetPlayerById(playerId);

            // Assert
            var notFoundResult = Assert.IsType<NotFoundObjectResult>(result);
            Assert.Equal("Player does not exist", notFoundResult.Value);
        }

        [Fact]
        public async Task GetPlayerById_ReturnsOkResult_WhenPlayerExists()
        {
            // Arrange
            int playerId = 1;
            var player = new Player { PlayerId = playerId, Name = "Hero", Level = 1 };
            _mockPlayerService.Setup(service => service.GetEntityById(playerId)).ReturnsAsync(player);

            // Act
            var result = await _controller.GetPlayerById(playerId);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(player, okResult.Value);
        }

        [Fact]
        public async Task GetPlayerById_ReturnsBadRequest_WhenExceptionIsThrown()
        {
            // Arrange
            int playerId = 1;
            _mockPlayerService.Setup(service => service.GetEntityById(playerId)).ThrowsAsync(new Exception("Some error"));

            // Act
            var result = await _controller.GetPlayerById(playerId);

            // Assert
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
            Assert.Equal("Some error", badRequestResult.Value.ToString());
        }
    }
}
