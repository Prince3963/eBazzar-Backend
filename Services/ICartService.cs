using eBazzar.DTO;
using eBazzar.HelperService;
using eBazzar.Model;
using static CartItemDTO;

namespace eBazzar.Services
{
    // IServices/ICartService.cs
    public interface ICartService
    {
        Task AddToCartAsync(AddToCartRequest request);
    }


}
