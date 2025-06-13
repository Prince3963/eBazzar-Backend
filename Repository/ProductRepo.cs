using eBazzar.DBcontext;
using eBazzar.DTO;
using eBazzar.Model;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Abstractions;
using Microsoft.VisualBasic;

namespace eBazzar.Repository
{
    public class ProductRepo : IProduct
    {
        private readonly AppDBContext dBContext;
        public ProductRepo(AppDBContext dBContext)
        {
            this.dBContext = dBContext;
        }


        public async Task<Product> addProduct(Product product)
        {
            if (product == null)
            {
                throw new ArgumentNullException(nameof(product));
            }
            await dBContext.products.AddAsync(product);
            await dBContext.SaveChangesAsync();
            return product;
        }

        public async Task<Product> deleteProduct(Product product)
        {
            var result = dBContext.products.Remove(product);
            if (result == null)
            {
                throw new NotImplementedException();
            }

            await dBContext.SaveChangesAsync();
            return product;
        }

        public async Task<Product> updateProduct(Product product, int product_id)
        {
            var result = await dBContext.products.FirstOrDefaultAsync(p => p.product_id == product_id);

            if (result == null)
            {
                return null;
            }

            result.product_name = product.product_name;
            result.product_description = product.product_description;
            result.product_price = product.product_price;
            result.product_image = product.product_image;
            result.product_isActive = product.product_isActive;
            result.category_id = product.category_id;
            result.Category = product.Category;

            await dBContext.SaveChangesAsync();
            return result;
        }


        public async Task<List<Product>> viewProduct()
        {
            return await dBContext.products.Include(p => p.Category).ToListAsync();
        }


        public async Task<Product?> deleteProductById(int product_id)
        {
            var existingProduct = await dBContext.products.FirstOrDefaultAsync(p => p.product_id == product_id);

            if (existingProduct == null)
            {
                return null;
            }

            dBContext.products.Remove(existingProduct);
            await dBContext.SaveChangesAsync();
            return existingProduct;
        }

        public async Task<Product> updateProductStatus(int product_id, ProductStatusDTO productStatusDTO)
        {
            var updateProduct = await dBContext.products.FirstOrDefaultAsync(p => p.product_id == product_id);

            updateProduct.product_isActive = productStatusDTO.product_isActive;

            await dBContext.SaveChangesAsync();
            return updateProduct; 
        }
        public async Task<Product?> getProductById(int product_id)
        {
            return await dBContext.products
                .Include(p => p.Category)
                .FirstOrDefaultAsync(p => p.product_id == product_id);
        }

        public async Task<List<Product>> getElectronicProduct(int category_id)
        {
            var existElectronicProduct = await dBContext.products
                .Include(c=>c.Category)
                .Where(c => c.category_id == category_id).ToListAsync();
            return existElectronicProduct;
        }
    }
}
