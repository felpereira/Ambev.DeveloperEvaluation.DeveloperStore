namespace Ambev.DeveloperEvaluation.Domain.Common
{
    public abstract class Entity<T>
    {
        public required T Id { get; set; }
    }
}
