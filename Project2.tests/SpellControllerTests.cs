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
    public class SpellControllerTests
    {
        private readonly Mock<IService<Spell>> _mockSpellService;
        private readonly SpellController _controller;

        public SpellControllerTests()
        {
            _mockSpellService = new Mock<IService<Spell>>();
            _controller = new SpellController(_mockSpellService.Object);
        }

        [Fact]
        public async Task GetAll_ReturnsOkResult_WithListOfSpells()
        {
            // Arrange
            var spells = new List<Spell>
            {
                new Spell { SpellId = 1, SpellName = "Fireball", Attack = 50, ManaCost = 10, ImageUrl = "fireball.png" },
                new Spell { SpellId = 2, SpellName = "Icebolt", Attack = 30, ManaCost = 5, ImageUrl = "icebolt.png" }
            };
            _mockSpellService.Setup(service => service.GetAllEntities())
                .ReturnsAsync(spells);

            // Act
            var result = await _controller.GetAll();

            // Assert
            var actionResult = Assert.IsType<ActionResult<IEnumerable<Spell>>>(result);
            var okResult = Assert.IsType<OkObjectResult>(actionResult.Result);
            var returnValue = Assert.IsType<List<Spell>>(okResult.Value);
            Assert.Equal(2, returnValue.Count);
        }

        [Fact]
        public async Task GetSpell_ReturnsOkResult_WithSpell()
        {
            // Arrange
            var spell = new Spell { SpellId = 1, SpellName = "Fireball", Attack = 50, ManaCost = 10, ImageUrl = "fireball.png" };
            _mockSpellService.Setup(service => service.GetEntityById(1))
                .ReturnsAsync(spell);

            // Act
            var result = await _controller.GetSpell(1);

            // Assert
            var actionResult = Assert.IsType<ActionResult<Spell>>(result);
            var okResult = Assert.IsType<OkObjectResult>(actionResult.Result);
            var returnValue = Assert.IsType<Spell>(okResult.Value);
            Assert.Equal("Fireball", returnValue.SpellName);
        }

        [Fact]
        public async Task GetSpell_ReturnsNotFound_WhenSpellDoesNotExist()
        {
            // Arrange
            _mockSpellService.Setup(service => service.GetEntityById(1))
                .ReturnsAsync((Spell)null);

            // Act
            var result = await _controller.GetSpell(1);

            // Assert
            var actionResult = Assert.IsType<ActionResult<Spell>>(result);
            var notFoundResult = Assert.IsType<NotFoundObjectResult>(actionResult.Result);
            Assert.Equal("Spell doesn't exist", notFoundResult.Value);
        }

        [Fact]
        public async Task GetSpell_ReturnsBadRequest_WhenExceptionIsThrown()
        {
            // Arrange
            _mockSpellService.Setup(service => service.GetEntityById(It.IsAny<int>()))
                .ThrowsAsync(new Exception("Some error"));

            // Act
            var result = await _controller.GetSpell(1);

            // Assert
            var actionResult = Assert.IsType<ActionResult<Spell>>(result);
            var objectResult = Assert.IsType<ObjectResult>(actionResult.Result);
            Assert.Equal(500, objectResult.StatusCode);
            Assert.Equal("Internal server error: Some error", objectResult.Value);
        }
    }
}
