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
    public class ItemServiceTests
    {
        private readonly Mock<IRepo<Item>> _mockItemRepo;
        private readonly ItemService _itemService;

        public ItemServiceTests()
        {
            _mockItemRepo = new Mock<IRepo<Item>>();
            _itemService = new ItemService(_mockItemRepo.Object);
        }

        [Fact]
        public async Task GetAllEntities_ShouldReturnListOfItems()
        {
            // Arrange
            var items = new List<Item>
            {
                new Item { ItemId = 1, ItemName = "Sword", Attack = 10, ImageUrl = "http://example.com/sword.png" },
                new Item { ItemId = 2, ItemName = "Shield", Attack = 5, ImageUrl = "http://example.com/shield.png" }
            };
            _mockItemRepo.Setup(repo => repo.GetAllEntities()).ReturnsAsync(items);

            // Act
            var result = await _itemService.GetAllEntities();

            // Assert
            Assert.Equal(items, result);
        }

        [Fact]
        public async Task GetEntityById_ShouldReturnItem_WhenIdIsValid()
        {
            // Arrange
            var item = new Item { ItemId = 1, ItemName = "Sword", Attack = 10, ImageUrl = "http://example.com/sword.png" };
            _mockItemRepo.Setup(repo => repo.GetById(1)).ReturnsAsync(item);

            // Act
            var result = await _itemService.GetEntityById(1);

            // Assert
            Assert.Equal(item, result);
        }

        [Fact]
        public async Task GetEntityById_ShouldThrowException_WhenIdIsLessThanOne()
        {
            // Act & Assert
            var exception = await Assert.ThrowsAsync<Exception>(() => _itemService.GetEntityById(0));
            Assert.Equal("Item Id cannot be less than 1", exception.Message);
        }

        [Fact]
        public async Task GetEntityById_ShouldReturnNull_WhenItemDoesNotExist()
        {
            // Arrange
            _mockItemRepo.Setup(repo => repo.GetById(It.IsAny<int>())).ReturnsAsync((Item)null);

            // Act
            var result = await _itemService.GetEntityById(999);

            // Assert
            Assert.Null(result);
        }
    }
}
