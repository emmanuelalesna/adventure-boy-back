using Project2.app.Models;
using Xunit;

namespace Project2.Tests.Models
{
    public class PlayerTests
    {
        [Fact]
        public void PlayerId_ShouldGetAndSet()
        {
            // Arrange
            var player = new Player { Name = "TestPlayer" };

            // Act
            player.PlayerId = 1;

            // Assert
            Assert.Equal(1, player.PlayerId);
        }

        [Fact]
        public void Name_ShouldGetAndSet()
        {
            // Arrange
            var player = new Player { Name = "TestPlayer" };

            // Act
            player.Name = "Hero";

            // Assert
            Assert.Equal("Hero", player.Name);
        }

        [Fact]
        public void CurrentHealth_ShouldGetAndSet()
        {
            // Arrange
            var player = new Player { Name = "TestPlayer" };

            // Act
            player.CurrentHealth = 20;

            // Assert
            Assert.Equal(20, player.CurrentHealth);
        }

        [Fact]
        public void CurrentMana_ShouldGetAndSet()
        {
            // Arrange
            var player = new Player { Name = "TestPlayer" };

            // Act
            player.CurrentMana = 5;

            // Assert
            Assert.Equal(5, player.CurrentMana);
        }

        [Fact]
        public void CurrentRoom_ShouldGetAndSet()
        {
            // Arrange
            var player = new Player { Name = "TestPlayer" };

            // Act
            player.CurrentRoom = 2;

            // Assert
            Assert.Equal(2, player.CurrentRoom);
        }

        [Fact]
        public void CurrentEnemyHealth_ShouldGetAndSet()
        {
            // Arrange
            var player = new Player { Name = "TestPlayer" };

            // Act
            player.CurrentEnemyHealth = 30;

            // Assert
            Assert.Equal(30, player.CurrentEnemyHealth);
        }

        [Fact]
        public void AccountOwner_ShouldGetAndSet()
        {
            // Arrange
            var player = new Player { Name = "TestPlayer" };
            var account = new Account();

            // Act
            player.AccountOwner = account;

            // Assert
            Assert.Equal(account, player.AccountOwner);
        }
    }
}
