using Project2.app.Models;
using Xunit;

namespace Project2.Tests.Models
{
    public class AccountTests
    {
        [Fact]
        public void AccountId_ShouldGetAndSet()
        {
            // Arrange
            var account = new Account();

            // Act
            account.AccountId = 1;

            // Assert
            Assert.Equal(1, account.AccountId);
        }

        [Fact]
        public void Username_ShouldGetAndSet()
        {
            // Arrange
            var account = new Account();

            // Act
            account.Username = "TestUser";

            // Assert
            Assert.Equal("TestUser", account.Username);
        }

        [Fact]
        public void Password_ShouldGetAndSet()
        {
            // Arrange
            var account = new Account();

            // Act
            account.Password = "TestPassword";

            // Assert
            Assert.Equal("TestPassword", account.Password);
        }

        [Fact]
        public void OwnedPlayer_ShouldGetAndSet()
        {
            // Arrange
            var account = new Account();
            var player = new Player
            {
                Name = "TestPlayer" // Set the required 'Name' property
            };

            // Act
            account.OwnedPlayer = player;

            // Assert
            Assert.Equal(player, account.OwnedPlayer);
        }

    }
}
