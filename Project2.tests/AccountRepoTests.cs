using Microsoft.EntityFrameworkCore;
using Project2.app.DataAccess;
using Project2.app.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace Project2.Tests
{
    public class AccountRepoTests
    {
        private ApplicationDbContext GetInMemoryDbContext()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            var context = new ApplicationDbContext(options);
            context.Database.EnsureCreated();
            return context;
        }

        [Fact]
        public async Task GetById_ReturnsAccountWithMatchingId()
        {
            // Arrange
            var context = GetInMemoryDbContext();
            var repo = new AccountRepo(context);
            var account = new Account { AccountId = 1, Username = "testuser", Password = "password123" };
            context.Accounts.Add(account);
            await context.SaveChangesAsync();

            // Act
            var result = await repo.GetById(1);

            // Assert
            Assert.Equal("testuser", result.Username);
        }

        [Fact]
        public async Task GetByUsername_ReturnsAccountWithMatchingUsername()
        {
            // Arrange
            var context = GetInMemoryDbContext();
            var repo = new AccountRepo(context);
            var account = new Account { AccountId = 1, Username = "testuser", Password = "password123" };
            context.Accounts.Add(account);
            await context.SaveChangesAsync();

            // Act
            var result = await repo.GetByUsername("testuser");

            // Assert
            Assert.Equal(1, result.AccountId);
        }

        [Fact]
        public async Task GetAllEntities_ReturnsAllAccounts()
        {
            // Arrange
            var context = GetInMemoryDbContext();
            var repo = new AccountRepo(context);
            var account1 = new Account { AccountId = 1, Username = "user1", Password = "password123" };
            var account2 = new Account { AccountId = 2, Username = "user2", Password = "password123" };
            context.Accounts.AddRange(account1, account2);
            await context.SaveChangesAsync();

            // Act
            var result = await repo.GetAllEntities();

            // Assert
            Assert.Equal(2, result.Count);
        }

        [Fact]
        public async Task UpdateEntity_UpdatesAccountAndSavesChanges()
        {
            // Arrange
            var context = GetInMemoryDbContext();
            var repo = new AccountRepo(context);
            var account = new Account { AccountId = 1, Username = "olduser", Password = "password123" };
            context.Accounts.Add(account);
            await context.SaveChangesAsync();

            var updates = new Dictionary<string, object>
            {
                { "Username", "newuser" }
            };

            // Act
            await repo.UpdateEntity(1, updates);
            var updatedAccount = await repo.GetById(1);

            // Assert
            Assert.Equal("newuser", updatedAccount.Username);
        }

        [Fact]
        public async Task DeleteEntity_RemovesAccountAndSavesChanges()
        {
            // Arrange
            var context = GetInMemoryDbContext();
            var repo = new AccountRepo(context);
            var account = new Account { AccountId = 1, Username = "user1", Password = "password123" };
            context.Accounts.Add(account);
            await context.SaveChangesAsync();

            // Act
            await repo.DeleteEntity(1);
            var result = await repo.GetById(1);

            // Assert
            Assert.Null(result);
        }
    }
}
