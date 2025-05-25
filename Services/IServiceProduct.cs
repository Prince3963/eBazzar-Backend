using eBazzar.DTO;
using eBazzar.HelperService;
using Microsoft.AspNetCore.Mvc;

namespace eBazzar.Services
{
    public interface IServiceProduct
    {
        
        Task<ServiceResponse<string>> addProduct(ProductDTO productDTO);
        Task<ServiceResponse<string>> updateProduct(ProductDTO productDTO,int product_id);
        Task<ServiceResponse<string>> deleteProduct(int product_id);
        Task<List<ProductDTO>> viewProduct();
        Task<ProductDTO?> getProductById(int product_id);

    }
}
