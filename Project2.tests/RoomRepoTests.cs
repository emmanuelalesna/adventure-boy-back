/*
using Microsoft.EntityFrameworkCore;
using Project2.app.DataAccess;
using Project2.app.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace Project2.Tests
{
    public class RoomRepoTests
    {
        private readonly ApplicationDbContext _context;
        private readonly RoomRepo _repo;

        public RoomRepoTests()
        {
            // Setup in-memory database
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase("TestDatabase")
                .Options;

            _context = new ApplicationDbContext(options);
            _repo = new RoomRepo(_context);

            // Seed the database
            SeedDatabase(_context);
        }

        private void SeedDatabase(ApplicationDbContext context)
        {
            context.Rooms.Add(new Room { RoomId = 1, ImageUrl = "http://example.com/room1.jpg" });
            context.Rooms.Add(new Room { RoomId = 2, ImageUrl = "http://example.com/room2.jpg" });
            context.SaveChanges();
        }

        [Fact]
        public async Task GetAllEntities_ShouldReturnAllRooms()
        {
            // Act
            var rooms = await _repo.GetAllEntities();

            // Assert
            Assert.Equal(2, rooms.Count);
            Assert.Contains(rooms, r => r.ImageUrl == "http://example.com/room1.jpg");
            Assert.Contains(rooms, r => r.ImageUrl == "http://example.com/room2.jpg");
        }

        [Fact]
        public async Task GetById_ShouldReturnRoomWithMatchingId()
        {
            // Act
            var room = await _repo.GetById(1);

            // Assert
            Assert.NotNull(room);
            Assert.Equal("http://example.com/room1.jpg", room?.ImageUrl);
        }

        [Fact]
        public async Task CreateEntity_ShouldAddRoomToDatabase()
        {
            // Arrange
            var newRoom = new Room { RoomId = 3, ImageUrl = "http://example.com/room3.jpg" };

            // Act
            var createdRoom = await _repo.CreateEntity(newRoom);

            // Assert
            Assert.NotNull(createdRoom);
            Assert.Equal(3, createdRoom.RoomId);
            Assert.Equal("http://example.com/room3.jpg", createdRoom.ImageUrl);

            var room = await _repo.GetById(3);
            Assert.NotNull(room);
            Assert.Equal("http://example.com/room3.jpg", room.ImageUrl);
        }

        [Fact]
        public async Task UpdateEntity_ShouldUpdateRoomAndSaveChanges()
        {
            // Arrange
            var updates = new Dictionary<string, object>
            {
                { "ImageUrl", "http://example.com/updated.jpg" }
            };

            // Act
            var updatedRoom = await _repo.UpdateEntity(1, updates);

            // Assert
            Assert.NotNull(updatedRoom);
            var room = await _repo.GetById(1);
            Assert.Equal("http://example.com/updated.jpg", room?.ImageUrl);
        }

        [Fact]
        public async Task DeleteEntity_ShouldRemoveRoomFromDatabase()
        {
            // Act
            var deletedRoom = await _repo.DeleteEntity(2);

            // Assert
            Assert.NotNull(deletedRoom);
            Assert.Null(await _repo.GetById(2));
        }
    }
}
*/