using System;
using Ambev.DeveloperEvaluation.Domain.Common;
using Ambev.DeveloperEvaluation.Domain.ValueObjects;

namespace Ambev.DeveloperEvaluation.Domain.Entities
{
    public class Product : Entity<Guid>
    {
        public decimal Price { get; private set; }
        public string Title { get; private set; }
        public string Description { get; private set; }
        public string Category { get; private set; }
        public string Image { get; private set; }
        public ProductRating ProductRating { get; private set; }

        protected Product() { }

        private Product(decimal price, string title, string description, string category, string image, ProductRating productRating)
        {
            Price = price;
            Title = title;
            Description = description;
            Category = category;
            Image = image;
            ProductRating = productRating ?? throw new ArgumentNullException(nameof(productRating));
        }

        public static Product Create(decimal price, string title, string description, string category, string image, ProductRating productRating)
        {
            Validate(price, title, category);
            return new Product(price, title, description, category, image, productRating) { Id = Guid.NewGuid() };
        }

        public void Update(decimal price, string title, string description, string category, string image, ProductRating productRating)
        {
            Validate(price, title, category);

            Price = price;
            Title = title;
            Description = description;
            Category = category;
            Image = image;
            ProductRating = productRating ?? throw new ArgumentNullException(nameof(productRating));
        }

        public void SetProductRate(ProductRating rating)
        {
            ProductRating = rating ?? throw new ArgumentNullException(nameof(rating));
        }

        private static void Validate(decimal price, string title, string category)
        {
            if (price < 0)
                throw new ArgumentOutOfRangeException(nameof(price), "O preço não pode ser negativo.");

            if (string.IsNullOrWhiteSpace(title))
                throw new ArgumentException("O título não pode ser nulo ou vazio.", nameof(title));

            if (string.IsNullOrWhiteSpace(category))
                throw new ArgumentException("A categoria não pode ser nula ou vazia.", nameof(category));
        }
    }
}