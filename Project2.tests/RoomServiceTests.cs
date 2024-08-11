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
    public class RoomServiceTests
    {
        private readonly Mock<IRepo<Room>> _mockRoomRepo;
        private readonly RoomService _roomService;

        public RoomServiceTests()
        {
            _mockRoomRepo = new Mock<IRepo<Room>>();
            _roomService = new RoomService(_mockRoomRepo.Object);
        }

        [Fact]
        public async Task GetAllEntities_ShouldReturnListOfRooms()
        {
            // Arrange
            var rooms = new List<Room>
            {
                new Room { RoomId = 1, ImageUrl = "http://example.com/room1.png" },
                new Room { RoomId = 2, ImageUrl = "http://example.com/room2.png" }
            };
            _mockRoomRepo.Setup(repo => repo.GetAllEntities()).ReturnsAsync(rooms);

            // Act
            var result = await _roomService.GetAllEntities();

            // Assert
            Assert.Equal(rooms, result);
        }

        [Fact]
        public async Task GetEntityById_ShouldReturnRoom_WhenIdIsValid()
        {
            // Arrange
            var room = new Room { RoomId = 1, ImageUrl = "http://example.com/room1.png" };
            _mockRoomRepo.Setup(repo => repo.GetById(1)).ReturnsAsync(room);

            // Act
            var result = await _roomService.GetEntityById(1);

            // Assert
            Assert.Equal(room, result);
        }

        [Fact]
        public async Task GetEntityById_ShouldReturnNull_WhenRoomDoesNotExist()
        {
            // Arrange
            _mockRoomRepo.Setup(repo => repo.GetById(It.IsAny<int>())).ReturnsAsync((Room)null);

            // Act
            var result = await _roomService.GetEntityById(999);

            // Assert
            Assert.Null(result);
        }

        [Fact]
        public async Task CreateNewEntity_ShouldThrowNotImplementedException()
        {
            // Act & Assert
            await Assert.ThrowsAsync<NotImplementedException>(() => _roomService.CreateNewEntity(new Room()));
        }

        [Fact]
        public async Task UpdateEntity_ShouldThrowNotImplementedException()
        {
            // Act & Assert
            await Assert.ThrowsAsync<NotImplementedException>(() => _roomService.UpdateEntity(1, new Dictionary<string, object>()));
        }

        [Fact]
        public async Task DeleteEntity_ShouldThrowNotImplementedException()
        {
            // Act & Assert
            await Assert.ThrowsAsync<NotImplementedException>(() => _roomService.DeleteEntity(1));
        }
    }
}
