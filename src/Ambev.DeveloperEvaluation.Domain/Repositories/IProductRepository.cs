using Ambev.DeveloperEvaluation.Domain.Entities;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Domain.Repositories
{
    public interface IProductRepository
    {
        Task<Product> AddAsync(Product product, CancellationToken cancellationToken);
        Task<Product> UpdateAsync(Product product);
        Task<bool> DeleteAsync(Product product);

        Task<Product?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
        Task<IEnumerable<Product>> GetAllAsync(int page, int pageSize, CancellationToken cancellationToken);
        Task<IEnumerable<Product>> GetByCategoryAsync(string category, int page, int pageSize, CancellationToken cancellationToken);
        Task<IEnumerable<string>> GetCategoriesAsync(CancellationToken cancellationToken);

        Task<int> GetCountAsync(CancellationToken cancellationToken);
        Task<int> GetCountByCategoryAsync(string category, CancellationToken cancellationToken);
    }
}