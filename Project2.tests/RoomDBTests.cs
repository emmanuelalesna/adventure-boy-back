using Project2.app.Models;
using Xunit;

namespace Project2.Tests.Models
{
    public class RoomTests
    {
        [Fact]
        public void RoomId_ShouldGetAndSet()
        {
            // Arrange
            var room = new Room();

            // Act
            room.RoomId = 1;

            // Assert
            Assert.Equal(1, room.RoomId);
        }

        [Fact]
        public void ImageUrl_ShouldGetAndSet()
        {
            // Arrange
            var room = new Room();

            // Act
            room.ImageUrl = "http://example.com/room.png";

            // Assert
            Assert.Equal("http://example.com/room.png", room.ImageUrl);
        }
    }
}
