using Microsoft.AspNetCore.Mvc;
using Moq;
using Project2.app.Controllers;
using Project2.app.Models;
using Project2.app.Services.Interface;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Xunit;

namespace Project2.Tests.Controllers
{
    public class AccountControllerTests
    {
        private readonly Mock<IAccountService> _mockAccountService;
        private readonly AccountController _accountController;

        public AccountControllerTests()
        {
            _mockAccountService = new Mock<IAccountService>();
            _accountController = new AccountController(_mockAccountService.Object);
        }

        [Fact]
        public async Task CreateAccount_ShouldReturnBadRequest_WhenAccountIsNull()
        {
            // Act
            var result = await _accountController.CreateAccount(null);

            // Assert
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
            Assert.Equal("Username and Password are required.", badRequestResult.Value);
        }

        [Fact]
        public async Task CreateAccount_ShouldReturnOk_WhenAccountIsValid()
        {
            // Arrange
            var account = new Account { Username = "testuser", Password = "password" };
            _mockAccountService.Setup(service => service.CreateNewEntity(account)).ReturnsAsync(account);

            // Act
            var result = await _accountController.CreateAccount(account);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(account, okResult.Value);
        }

        [Fact]
        public async Task GetAllAccounts_ShouldReturnOk_WithListOfAccounts()
        {
            // Arrange
            var accounts = new List<Account> { new Account { Username = "testuser1", Password = "password1" }, new Account { Username = "testuser2", Password = "password2" } };
            _mockAccountService.Setup(service => service.GetAllEntities()).ReturnsAsync(accounts);

            // Act
            var result = await _accountController.GetAllAccounts();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(accounts, okResult.Value);
        }

        [Fact]
        public async Task GetEntityByUsername_ShouldReturnOk_WhenAccountExists()
        {
            // Arrange
            var account = new Account { Username = "testuser", Password = "password" };
            _mockAccountService.Setup(service => service.GetEntityByUsername("testuser")).ReturnsAsync(account);

            // Act
            var result = await _accountController.GetEntityByUsername("testuser");

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(account, okResult.Value);
        }

        [Fact]
        public async Task GetEntityByUsername_ShouldReturnNotFound_WhenAccountDoesNotExist()
        {
            // Arrange
            _mockAccountService.Setup(service => service.GetEntityByUsername("unknownuser")).ReturnsAsync((Account)null);

            // Act
            var result = await _accountController.GetEntityByUsername("unknownuser");

            // Assert
            Assert.IsType<NotFoundObjectResult>(result);
        }

        [Fact]
        public async Task DeleteAccount_ShouldReturnNoContent_WhenAccountIsDeleted()
        {
            // Arrange
            var account = new Account { AccountId = 1, Username = "testuser", Password = "password" };
            _mockAccountService.Setup(service => service.DeleteEntity(1)).ReturnsAsync(account);

            // Act
            var result = await _accountController.DeleteAccount(1);

            // Assert
            Assert.IsType<NoContentResult>(result);
        }

        [Fact]
        public async Task DeleteAccount_ShouldReturnNotFound_WhenAccountDoesNotExist()
        {
            // Arrange
            _mockAccountService.Setup(service => service.DeleteEntity(1)).ReturnsAsync((Account)null);

            // Act
            var result = await _accountController.DeleteAccount(1);

            // Assert
            Assert.IsType<NotFoundObjectResult>(result);
        }
    }
}
