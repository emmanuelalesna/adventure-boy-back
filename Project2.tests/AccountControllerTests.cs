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
    public class AccountControllerTests
    {
        private readonly Mock<IAccountService> _mockAccountService;
        private readonly AccountController _controller;

        public AccountControllerTests()
        {
            _mockAccountService = new Mock<IAccountService>();
            _controller = new AccountController(_mockAccountService.Object);
        }

        [Fact]
        public async Task CreateAccount_ReturnsOkResult_WithCreatedAccount()
        {
            // Arrange
            var account = new Account { Username = "user", Password = "password" };
            _mockAccountService.Setup(service => service.CreateNewEntity(account)).ReturnsAsync(account);

            // Act
            var result = await _controller.CreateAccount(account);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsType<Account>(okResult.Value);
            Assert.Equal(account.Username, returnValue.Username);
        }

        [Fact]
        public async Task CreateAccount_ReturnsBadRequest_WhenAccountIsNull()
        {
            // Arrange

            // Act
            var result = await _controller.CreateAccount(null);

            // Assert
            Assert.IsType<BadRequestObjectResult>(result);
        }

        [Fact]
        public async Task CreateAccount_ReturnsBadRequest_WhenExceptionIsThrown()
        {
            // Arrange
            var account = new Account { Username = "user", Password = "password" };
            var exceptionMessage = "Invalid data";
            _mockAccountService.Setup(service => service.CreateNewEntity(account)).ThrowsAsync(new InvalidDataException(exceptionMessage));

            // Act
            var result = await _controller.CreateAccount(account);

            // Assert
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
            Assert.Contains(exceptionMessage, badRequestResult.Value.ToString());
        }

        [Fact]
        public async Task GetAllAccounts_ReturnsOkResult_WithListOfAccounts()
        {
            // Arrange
            var accounts = new List<Account> { new Account { Username = "user1" }, new Account { Username = "user2" } };
            _mockAccountService.Setup(service => service.GetAllEntities()).ReturnsAsync(accounts);

            // Act
            var result = await _controller.GetAllAccounts();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsType<List<Account>>(okResult.Value);
            Assert.Equal(2, returnValue.Count);
        }

        [Fact]
        public async Task GetEntityByUsername_ReturnsOkResult_WithAccount()
        {
            // Arrange
            string username = "user";
            var account = new Account { Username = username };
            _mockAccountService.Setup(service => service.GetEntityByUsername(username)).ReturnsAsync(account);

            // Act
            var result = await _controller.GetEntityByUsername(username);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsType<Account>(okResult.Value);
            Assert.Equal(username, returnValue.Username);
        }

        [Fact]
        public async Task DeleteAccount_ReturnsNoContentResult_WhenAccountIsDeleted()
        {
            // Arrange
            int accountId = 1;
            var account = new Account { AccountId = accountId };
            _mockAccountService.Setup(service => service.DeleteEntity(accountId)).ReturnsAsync(account);

            // Act
            var result = await _controller.DeleteAccount(accountId);

            // Assert
            Assert.IsType<NoContentResult>(result);
        }

        [Fact]
        public async Task DeleteAccount_ReturnsBadRequest_WhenExceptionIsThrown()
        {
            // Arrange
            int accountId = 1;
            var exceptionMessage = "Error deleting account";
            _mockAccountService.Setup(service => service.DeleteEntity(accountId)).ThrowsAsync(new Exception(exceptionMessage));

            // Act
            var result = await _controller.DeleteAccount(accountId);

            // Assert
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
            Assert.Contains(exceptionMessage, badRequestResult.Value.ToString());
        }
    }
}
