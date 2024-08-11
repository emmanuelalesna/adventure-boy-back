using Project2.app.Models;
using Xunit;

namespace Project2.Tests.Models
{
    public class SpellTests
    {
        [Fact]
        public void SpellId_ShouldGetAndSet()
        {
            // Arrange
            var spell = new Spell();

            // Act
            spell.SpellId = 1;

            // Assert
            Assert.Equal(1, spell.SpellId);
        }

        [Fact]
        public void SpellName_ShouldGetAndSet()
        {
            // Arrange
            var spell = new Spell();

            // Act
            spell.SpellName = "Fireball";

            // Assert
            Assert.Equal("Fireball", spell.SpellName);
        }

        [Fact]
        public void Attack_ShouldGetAndSet()
        {
            // Arrange
            var spell = new Spell();

            // Act
            spell.Attack = 25;

            // Assert
            Assert.Equal(25, spell.Attack);
        }

        [Fact]
        public void ManaCost_ShouldGetAndSet()
        {
            // Arrange
            var spell = new Spell();

            // Act
            spell.ManaCost = 5;

            // Assert
            Assert.Equal(5, spell.ManaCost);
        }

        [Fact]
        public void ImageUrl_ShouldGetAndSet()
        {
            // Arrange
            var spell = new Spell();

            // Act
            spell.ImageUrl = "http://example.com/spell.png";

            // Assert
            Assert.Equal("http://example.com/spell.png", spell.ImageUrl);
        }
    }
}
