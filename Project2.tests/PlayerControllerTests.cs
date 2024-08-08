using Xunit;
using Moq;
using Microsoft.AspNetCore.Mvc;
using Project2.app.Controllers;
using Project2.app.Models;
using Project2.app.Services.Interface;
using System.Threading.Tasks;
using System.Collections.Generic;
using System;

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
        public async Task CreatePlayer_ReturnsOkResult_WithCreatedPlayer()
        {
            // Arrange
            var player = new Player { Name = "TestPlayer", Level = 1 };
            _mockPlayerService.Setup(service => service.CreateNewEntity(player)).ReturnsAsync(player);

            // Act
            var result = await _controller.CreatePlayer(player);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsType<Player>(okResult.Value);
            Assert.Equal(player.Name, returnValue.Name);
        }

        [Fact]
        public async Task GetAllPlayers_ReturnsOkResult_WithListOfPlayers()
        {
            // Arrange
            var players = new List<Player> { new Player { Name = "TestPlayer1" }, new Player { Name = "TestPlayer2" } };
            _mockPlayerService.Setup(service => service.GetAllEntities()).ReturnsAsync(players);

            // Act
            var result = await _controller.GetAllPlayers();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsType<List<Player>>(okResult.Value);
            Assert.Equal(2, returnValue.Count);
        }

        [Fact]
        public async Task GetPlayerById_ReturnsOkResult_WithPlayer()
        {
            // Arrange
            int playerId = 1;
            var player = new Player { PlayerId = playerId, Name = "TestPlayer" };
            _mockPlayerService.Setup(service => service.GetEntityById(playerId)).ReturnsAsync(player);

            // Act
            var result = await _controller.GetPlayerById(playerId);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsType<Player>(okResult.Value);
            Assert.Equal(playerId, returnValue.PlayerId);
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
            Assert.IsType<NotFoundObjectResult>(result);
        }

        [Fact]
        public async Task GetPlayerById_ReturnsBadRequest_WhenExceptionIsThrown()
        {
            // Arrange
            int playerId = 1;
            var exceptionMessage = "Some error";
            _mockPlayerService.Setup(service => service.GetEntityById(playerId)).ThrowsAsync(new Exception(exceptionMessage));

            // Act
            var result = await _controller.GetPlayerById(playerId);

            // Assert
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
            Assert.Contains(exceptionMessage, badRequestResult.Value.ToString());
        }
    }
}
