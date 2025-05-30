using eBazzar.DTO;
using eBazzar.Model;

namespace eBazzar.Repository
{
    // IRepository/ICartItemRepository.cs
    public interface ICartItemRepository
    {
        Task<CartItem?> GetCartItemAsync(int? userId, int productId);
        Task AddCartItemAsync(CartItem cartItem);
        Task UpdateCartItemAsync(CartItem cartItem);
        Task SaveChangesAsync();
    }

}
