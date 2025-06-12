using AutoMapper;
using Moq;
using FluentAssertions;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Ambev.DeveloperEvaluation.Application.Products.CreateProduct;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Unit.Domain.Entities.TestData;
using Ambev.DeveloperEvaluation.Application.Products.UpdateProduct;
using Ambev.DeveloperEvaluation.Application.Products.DeleteProduct;
using Ambev.DeveloperEvaluation.Application.Products.GetProductById;
using Ambev.DeveloperEvaluation.Application.Products.GetAllProducts;
using System.Linq.Expressions;
using Ambev.DeveloperEvaluation.Application.Products.GetProductsByCategories;
using Ambev.DeveloperEvaluation.Application.Products.GetCategories;
using Xunit;

// In a real scenario, they would be in separate files.

namespace Ambev.DeveloperEvaluation.Unit.Application.Products
{
    // CREATE PRODUCT HANDLER TESTS
    public class CreateProductHandlerTests
    {
        private readonly Mock<IProductRepository> _productRepositoryMock;
        private readonly Mock<IMapper> _mapperMock;
        private readonly CreateProductHandler _handler;

        public CreateProductHandlerTests()
        {
            _productRepositoryMock = new Mock<IProductRepository>();
            _mapperMock = new Mock<IMapper>();
            _handler = new CreateProductHandler(_productRepositoryMock.Object, _mapperMock.Object);
        }

        [Fact]
        public async Task Handle_ShouldAddProductAndReturnResult_WhenCommandIsValid()
        {
            // Arrange
            var command = new CreateProductCommand(10, "Test", "Desc", "Cat", "Img", new DeveloperEvaluation.Application.Products.ProductRatingDto());
            var product = ProductTestData.CreateValidProduct();
            var productResult = new CreateProductResult { Id = product.Id };

            _mapperMock.Setup(m => m.Map<Product>(command)).Returns(product);
            _mapperMock.Setup(m => m.Map<CreateProductResult>(product)).Returns(productResult);

            // Act
            var result = await _handler.Handle(command, CancellationToken.None);

            // Assert
            _productRepositoryMock.Verify(r => r.AddAsync(product, It.IsAny<CancellationToken>()), Times.Once);
            result.Should().BeEquivalentTo(productResult);
        }
    }
}
// UPDATE PRODUCT HANDLER TESTS
// DELETE PRODUCT HANDLER TESTS
// GET PRODUCT BY ID HANDLER TESTS
// GET ALL PRODUCTS HANDLER TESTS
// GET PRODUCTS BY CATEGORIES HANDLER TESTS
// GET CATEGORIES HANDLER TESTS

