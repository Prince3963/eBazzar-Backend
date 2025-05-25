using eBazzar.DTO;
using eBazzar.Model;

namespace eBazzar.Repository
{
    public interface IProduct
    {
        Task<Product> addProduct(Product product);
        Task<Product> updateProduct(Product product, int product_id);
        Task<Product> deleteProduct(Product product);
        Task<List<Product>> viewProduct();

        Task<Product?> deleteProductById(int product_id);

        Task<Product> getProductById(int product_id);
    }
}
