using Microsoft.AspNetCore.Mvc;
using Moq;
using Project2.app.Controllers;
using Project2.app.Models;
using Project2.app.Services.Interface;
using Xunit;

namespace Project2.Tests
{
    public class RoomControllerTests
    {
        private readonly RoomController _controller;
        private readonly Mock<IService<Room>> _mockService;

        public RoomControllerTests()
        {
            _mockService = new Mock<IService<Room>>();
            _controller = new RoomController(_mockService.Object);
        }

        [Fact]
        public async Task GetAllRooms_ReturnsOkResult_WithListOfRooms()
        {
            // Arrange
            var mockRooms = new List<Room>
            {
                new Room { RoomId = 1, ImageUrl = "room1.jpg" },
                new Room { RoomId = 2, ImageUrl = "room2.jpg" }
            };
            _mockService.Setup(service => service.GetAllEntities()).ReturnsAsync(mockRooms);

            // Act
            var result = await _controller.GetAllRooms();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsType<List<Room>>(okResult.Value);
            Assert.Equal(mockRooms.Count, returnValue.Count);
        }

        [Fact]
        public async Task GetRoom_ReturnsOkResult_WithRoom()
        {
            // Arrange
            var roomId = 1;
            var mockRoom = new Room { RoomId = roomId, ImageUrl = "room1.jpg" };
            _mockService.Setup(service => service.GetEntityById(roomId)).ReturnsAsync(mockRoom);

            // Act
            var result = await _controller.GetRoom(roomId);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsType<Room>(okResult.Value);
            Assert.Equal(roomId, returnValue.RoomId);
        }

        [Fact]
        public async Task GetRoom_ReturnsNotFound_WhenRoomDoesNotExist()
        {
            // Arrange
            var roomId = 1;
            _mockService.Setup(service => service.GetEntityById(roomId)).ReturnsAsync((Room)null);

            // Act
            var result = await _controller.GetRoom(roomId);

            // Assert
            var notFoundResult = Assert.IsType<NotFoundObjectResult>(result);
            Assert.Equal("Room doesn't Exist", notFoundResult.Value);
        }

        [Fact]
        public async Task GetRoom_ReturnsBadRequest_WhenExceptionIsThrown()
        {
            // Arrange
            var roomId = 1;
            var expectedErrorMessage = "Some error";
            
            // Setup the mock to throw an exception when GetEntityById is called
            _mockService.Setup(service => service.GetEntityById(roomId))
                        .ThrowsAsync(new Exception(expectedErrorMessage));

            // Act
            var result = await _controller.GetRoom(roomId);

            // Assert
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
            Assert.Equal(expectedErrorMessage, badRequestResult.Value.ToString());
        }

    }
}
