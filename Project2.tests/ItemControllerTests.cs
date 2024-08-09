using Microsoft.AspNetCore.Mvc;
using Moq;
using Project2.app.Controllers;
using Project2.app.Models;
using Project2.app.Services.Interface;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace Project2.Tests
{
    public class ItemControllerTests
    {
        [Fact]
        public async Task GetAll_ReturnsInternalServerError_WhenExceptionIsThrown()
        {
            // Arrange
            var mockService = new Mock<IService<Item>>();
            mockService.Setup(service => service.GetAllEntities()).ThrowsAsync(new Exception("Some error"));
            var controller = new ItemController(mockService.Object);

            // Act
            var result = await controller.GetAll();

            // Assert
            var objectResult = Assert.IsType<ObjectResult>(result);
            Assert.Equal(500, objectResult.StatusCode);
            Assert.Equal("Internal server error", objectResult.Value);
        }

        [Fact]
        public async Task GetItem_ReturnsInternalServerError_WhenExceptionIsThrown()
        {
            // Arrange
            var mockService = new Mock<IService<Item>>();
            mockService.Setup(service => service.GetEntityById(It.IsAny<int>())).ThrowsAsync(new Exception("Some error"));
            var controller = new ItemController(mockService.Object);

            // Act
            var result = await controller.GetItem(1);

            // Assert
            var objectResult = Assert.IsType<ObjectResult>(result);
            Assert.Equal(500, objectResult.StatusCode);
            Assert.Equal("Internal server error", objectResult.Value);
        }

        [Fact]
        public async Task GetAll_ReturnsOkResult_WithItems()
        {
            // Arrange
            var mockService = new Mock<IService<Item>>();
            var items = new List<Item> { new Item { ItemId = 1, ItemName = "Item1" } };
            mockService.Setup(service => service.GetAllEntities()).ReturnsAsync(items);
            var controller = new ItemController(mockService.Object);

            // Act
            var result = await controller.GetAll();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnedItems = Assert.IsType<List<Item>>(okResult.Value);
            Assert.Single(returnedItems);
        }

        [Fact]
        public async Task GetItem_ReturnsOkResult_WithItem()
        {
            // Arrange
            var mockService = new Mock<IService<Item>>();
            var item = new Item { ItemId = 1, ItemName = "Item1" };
            mockService.Setup(service => service.GetEntityById(It.IsAny<int>())).ReturnsAsync(item);
            var controller = new ItemController(mockService.Object);

            // Act
            var result = await controller.GetItem(1);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnedItem = Assert.IsType<Item>(okResult.Value);
            Assert.Equal(item.ItemId, returnedItem.ItemId);
        }

        [Fact]
        public async Task GetItem_ReturnsNotFound_WhenItemDoesNotExist()
        {
            // Arrange
            var mockService = new Mock<IService<Item>>();
            mockService.Setup(service => service.GetEntityById(It.IsAny<int>())).ReturnsAsync((Item)null);
            var controller = new ItemController(mockService.Object);

            // Act
            var result = await controller.GetItem(1);

            // Assert
            var notFoundResult = Assert.IsType<NotFoundObjectResult>(result);
            Assert.Equal("Item doesn't Exist", notFoundResult.Value);
        }
    }
}
