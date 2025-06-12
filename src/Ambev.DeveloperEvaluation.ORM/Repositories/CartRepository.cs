using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Ambev.DeveloperEvaluation.ORM.Repositories
{
    public class CartRepository : ICartRepository
    {
        private readonly DefaultContext _context;

        public CartRepository(DefaultContext context)
        {
            _context = context;
        }

        public async Task<Cart> AddAsync(Cart cart, CancellationToken cancellationToken)
        {
            _context.Carts.Add(cart);
            await _context.SaveChangesAsync(cancellationToken);
            return cart;
        }

        public async Task<Cart> UpdateAsync(Cart cart, CancellationToken cancellationToken)
        {
            _context.Carts.Update(cart);
            await _context.SaveChangesAsync(cancellationToken);
            return cart;
        }

        public async Task<bool> DeleteAsync(Cart cart, CancellationToken cancellationToken)
        {
            _context.Carts.Remove(cart);
            await _context.SaveChangesAsync(cancellationToken);
            return true;
        }

        public async Task<Cart?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            return await _context.Carts.FirstOrDefaultAsync(p => p.Id == id, cancellationToken);
        }

        public async Task<Cart?> GetByUserIdAsync(Guid userId, CancellationToken cancellationToken)
        {
            return await _context.Carts.FirstOrDefaultAsync(c => c.UserId == userId, cancellationToken);
        }

        public async Task<IEnumerable<Cart>> GetAllAsync(int page, int pageSize, CancellationToken cancellationToken)
        {
            return await _context.Carts
                .AsNoTracking()
                .OrderByDescending(p => p.Date)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync(cancellationToken);
        }

        public async Task<int> GetCountAsync(CancellationToken cancellationToken)
        {
            return await _context.Carts.CountAsync(cancellationToken);
        }

    }
}