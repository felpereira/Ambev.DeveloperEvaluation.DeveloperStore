namespace Ambev.DeveloperEvaluation.Domain.ValueObjects
{
    public record ProductRating
    {
        public int Count { get; }
        public double Rating { get; }

        public ProductRating(int count, double rating)
        {
            if (count < 0)
                throw new ArgumentOutOfRangeException(nameof(count), "A quantidade de avaliações não pode ser negativa.");

            if (rating < 0 || rating > 5)
                throw new ArgumentOutOfRangeException(nameof(rating), "A nota da avaliação deve estar entre 0 e 5.");

            Count = count;
            Rating = rating;
        }
    }
}