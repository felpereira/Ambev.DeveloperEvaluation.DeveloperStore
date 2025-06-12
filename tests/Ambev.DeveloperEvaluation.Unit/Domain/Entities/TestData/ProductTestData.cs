using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.ValueObjects;

namespace Ambev.DeveloperEvaluation.Unit.Domain.Entities.TestData
{
    public static class ProductTestData
    {
        public static Product CreateValidProduct()
        {
            var rating = new ProductRating(1, 2);

            return Product.Create(
                6.99m,
                "Guaraná Antarctica",
                "Refrigerante de Guaraná",
                "Refrigerante",
                "Ambev", rating

            );
        }

        public static List<Product> CreateProductList()
        {
            return
            [
                Product.Create(
                6.91m,
                "Guaraná Antarctica1",
                "Refrigerante de Guaraná1",
                "Refrigerante1",
                "Ambev1", new ProductRating(1, 2)

            ),
                Product.Create(
                6.92m,
                "Guaraná Antarctica2",
                "Refrigerante de Guaraná2",
                "Refrigerante2",
                "Ambev2", new ProductRating(1, 2)

            ),
                Product.Create(
                6.93m,
                "Guaraná Antarctica3",
                "Refrigerante de Guaraná3",
                "Refrigerante3",
                "Ambev3", new ProductRating(1, 2)

            )
            ];
        }
    }
}
