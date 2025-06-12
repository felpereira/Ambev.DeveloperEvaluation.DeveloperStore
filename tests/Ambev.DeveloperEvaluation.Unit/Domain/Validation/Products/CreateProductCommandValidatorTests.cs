using FluentValidation.TestHelper;
using Ambev.DeveloperEvaluation.Application.Products.CreateProduct;
using Xunit;


namespace Ambev.DeveloperEvaluation.Unit.Application.Products.Validators
{

    public class CreateProductCommandValidatorTests
    {
        private readonly CreateProductCommandValidator _validator = new();

        [Fact]
        public void Should_Have_Error_When_Name_Is_Empty()
        {
            var model = new CreateProductCommand(10.99m, "", "Desc", "Brand", "Category", new Ambev.DeveloperEvaluation.Application.Products.ProductRatingDto(1, 2));
            var result = _validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(x => x.Title);
        }
        [Fact]
        public void Should_Have_Error_When_Price_Is_Zero()
        {
            // Pass an invalid Price value (0) and valid other fields.
            var model = new CreateProductCommand(0, "Test Product", "Desc", "Brand", "Category", new Ambev.DeveloperEvaluation.Application.Products.ProductRatingDto(1, 2));
            var result = _validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(x => x.Price);
        }
        [Fact]
        public void Should_Not_Have_Error_When_Command_Is_Valid()
        {
            // Provide all valid constructor arguments.
            var model = new CreateProductCommand(10.99m, "Test Product", "Desc", "Brand", "Category", new Ambev.DeveloperEvaluation.Application.Products.ProductRatingDto(1, 2));
            var result = _validator.TestValidate(model);
            result.ShouldNotHaveAnyValidationErrors();
        }

    }

    // UPDATE PRODUCT VALIDATOR TESTS

    // DELETE PRODUCT VALIDATOR TESTS


    // GET PRODUCT BY ID VALIDATOR TESTS


    // GET ALL PRODUCTS VALIDATOR TESTS


    // GET PRODUCTS BY CATEGORIES VALIDATOR TESTS

}
