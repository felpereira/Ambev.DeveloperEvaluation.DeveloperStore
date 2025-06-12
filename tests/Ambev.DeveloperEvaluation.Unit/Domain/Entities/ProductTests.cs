using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.ValueObjects;
using Ambev.DeveloperEvaluation.Unit.Domain.Entities.TestData;
using FluentAssertions;
using Xunit;

namespace Ambev.DeveloperEvaluation.Unit.Domain.Entities
{
    public class ProductTests
    {
        [Fact]
        public void Constructor_ShouldCreateProduct_WhenDataIsValid()
        {
            // Arrange
            const string title = "Skol";
            const string description = "Cerveja Pilsen";
            const decimal price = 4.50m;
            const string category = "Cerveja";
            const string img = "img/test";
            var rating = new ProductRating(1, 2);

            // Act
            var product = Product.Create(price, title, description, category, img, rating);

            // Assert
            product.Title.Should().Be(title);
            product.Description.Should().Be(description);
            product.Price.Should().Be(price);
            product.Category.Should().Be(category);
        }

        [Theory]
        [InlineData("", "Description", 10.0, "Brand", "Category")]
        [InlineData("Name", "", 10.0, "Brand", "Category")]
        [InlineData("Name", "Description", 0, "Brand", "Category")]
        public void Constructor_ShouldThrowDomainException_WhenDataIsInvalid(
            string title, string description, decimal price, string category, string expectedMessage)
        {
            // Act
            var rating = new ProductRating(1, 2);
            Action act = () => Product.Create(price, title, description, category, "img", rating); ;

            // Assert
            act.Should().Throw<DomainException>().WithMessage(expectedMessage);
        }

        [Fact]
        public void Update_ShouldUpdateProduct_WhenDataIsValid()
        {
            // Arrange
            var product = ProductTestData.CreateValidProduct();
            const string newName = "Brahma";
            const string newDescription = "Cerveja Duplo Malte";
            const decimal newPrice = 5.00m;
            const string img = "Ambev";
            const string newCategory = "Cerveja";
            var rating = new ProductRating(1, 2);


            // Act
            product.Update(newPrice, newName, newDescription, newCategory, img, rating);

            // Assert
            product.Title.Should().Be(newName);
            product.Description.Should().Be(newDescription);
            product.Price.Should().Be(newPrice);
            product.Image.Should().Be(img);
            product.Category.Should().Be(newCategory);
        }

        [Theory]
        [InlineData("", "Description", 10.0, "Brand", "Category", "Name is required")]
        [InlineData("Name", "", 10.0, "Brand", "Category", "Description is required")]
        [InlineData("Name", "Description", -1, "Brand", "Category", "Price must be greater than zero")]
        public void Update_ShouldThrowDomainException_WhenDataIsInvalid(
            string name, string description, decimal price, string brand, string category, string expectedMessage)
        {
            // Arrange
            var product = ProductTestData.CreateValidProduct();
            var rating = new ProductRating(1, 2);

            // Act
            Action act = () => product.Update(price, name, description, category, brand, rating);

            // Assert
            act.Should().Throw<DomainException>().WithMessage(expectedMessage);
        }
    }
}
