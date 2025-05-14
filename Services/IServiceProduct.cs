using eBazzar.DTO;
using eBazzar.HelperService;
using Microsoft.AspNetCore.Mvc;

namespace eBazzar.Services
{
    public interface IServiceProduct
    {
        
        Task<ServiceResponse<string>> addProduct(ProductDTO productDTO);
        Task<ServiceResponse<string>> updateProduct(ProductDTO productDTO,int product_id);
        Task<ProductDTO> deleteProduct(ProductDTO productDTO);
        Task<List<ProductDTO>> viewProduct();
    }
}
