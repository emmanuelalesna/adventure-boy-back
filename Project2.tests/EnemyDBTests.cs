using Project2.app.Models;
using Xunit;

namespace Project2.Tests.Models
{
    public class EnemyTests
    {
        [Fact]
        public void EnemyId_ShouldGetAndSet()
        {
            // Arrange
            var enemy = new Enemy();

            // Act
            enemy.EnemyId = 1;

            // Assert
            Assert.Equal(1, enemy.EnemyId);
        }

        [Fact]
        public void EnemyName_ShouldGetAndSet()
        {
            // Arrange
            var enemy = new Enemy();

            // Act
            enemy.EnemyName = "Goblin";

            // Assert
            Assert.Equal("Goblin", enemy.EnemyName);
        }

        [Fact]
        public void Attack_ShouldGetAndSet()
        {
            // Arrange
            var enemy = new Enemy();

            // Act
            enemy.Attack = 15;

            // Assert
            Assert.Equal(15, enemy.Attack);
        }

        [Fact]
        public void Health_ShouldGetAndSet()
        {
            // Arrange
            var enemy = new Enemy();

            // Act
            enemy.Health = 100;

            // Assert
            Assert.Equal(100, enemy.Health);
        }

        [Fact]
        public void ImageUrl_ShouldGetAndSet()
        {
            // Arrange
            var enemy = new Enemy();

            // Act
            enemy.ImageUrl = "http://example.com/image.png";

            // Assert
            Assert.Equal("http://example.com/image.png", enemy.ImageUrl);
        }
    }
}
