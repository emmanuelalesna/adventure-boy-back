using Project2.app.Models;
using Xunit;

namespace Project2.Tests.Models
{
    public class ItemTests
    {
        [Fact]
        public void ItemId_ShouldGetAndSet()
        {
            // Arrange
            var item = new Item();

            // Act
            item.ItemId = 1;

            // Assert
            Assert.Equal(1, item.ItemId);
        }

        [Fact]
        public void ItemName_ShouldGetAndSet()
        {
            // Arrange
            var item = new Item();

            // Act
            item.ItemName = "Sword";

            // Assert
            Assert.Equal("Sword", item.ItemName);
        }

        [Fact]
        public void Attack_ShouldGetAndSet()
        {
            // Arrange
            var item = new Item();

            // Act
            item.Attack = 10;

            // Assert
            Assert.Equal(10, item.Attack);
        }

        [Fact]
        public void ImageUrl_ShouldGetAndSet()
        {
            // Arrange
            var item = new Item();

            // Act
            item.ImageUrl = "http://example.com/sword.png";

            // Assert
            Assert.Equal("http://example.com/sword.png", item.ImageUrl);
        }
    }
}
