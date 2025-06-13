using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Domain.Repositories
{
    public interface ICartRepository
    {
        Task<Cart?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
        Task<Cart?> GetByUserIdAsync(Guid userId, CancellationToken cancellationToken);
        Task<IEnumerable<Cart>> GetAllAsync(int page, int pageSize, CancellationToken cancellationToken);
        Task<int> GetCountAsync(CancellationToken cancellationToken);
        Task<Cart> AddAsync(Cart cart, CancellationToken cancellationToken);
        Task<Cart> UpdateAsync(Cart cart, CancellationToken cancellationToken);
        Task<bool> DeleteAsync(Cart cart, CancellationToken cancellationToken);
    }
}