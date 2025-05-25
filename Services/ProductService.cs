using Azure;
using eBazzar.DTO;
using eBazzar.HelperService;
using eBazzar.Model;
using eBazzar.Repository;

namespace eBazzar.Services
{
    public class ProductService : IServiceProduct
    {
        private readonly IProduct iproduct;
        private readonly ICloudinaryService cloudinaryService;
        public ProductService(IProduct iproduct, ICloudinaryService cloudinaryService)
        {
            this.iproduct = iproduct;
            this.cloudinaryService = cloudinaryService;
        }


        public async Task<ServiceResponse<string>> addProduct(ProductDTO productDTO)
        {
            try
            {

                var resultResponse = new ServiceResponse<string>();
                var imageURL = await cloudinaryService.uploadImages(productDTO.product_image);

                Console.WriteLine("Received file: " + productDTO.product_image?.FileName);

                if (imageURL == null)
                {
                    resultResponse.data = "0";
                    resultResponse.message = "Image upload failed.";
                    resultResponse.status = false;
                    return resultResponse;
                }

                var existProduct = new Product
                {
                    product_name = productDTO.product_name,
                    product_description = productDTO.product_description,
                    product_price = productDTO.product_price,
                    product_image = imageURL,
                    product_isActive = productDTO.product_isActive,
                    category_id = productDTO.category_id

                };

                var newProduct = await iproduct.addProduct(existProduct);
                if (newProduct != null)
                {
                    resultResponse.data = "1";
                    resultResponse.message = "Product added successfully";
                    resultResponse.status = true;
                }

                return resultResponse;
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR in company service in createCompanyProfile method: " + ex.Message);
                throw;
            }
        }

        public async Task<ServiceResponse<string>> deleteProduct(int product_id)
        {
            var resultResponse = new ServiceResponse<string>();

            if (product_id == null)
            {
                resultResponse.data = "0";
                resultResponse.message = "Product Id is requierd";
                resultResponse.status = false;

                return resultResponse;
            }

            var existingProduct = await iproduct.deleteProductById(product_id);
            if (existingProduct == null)
            {
                resultResponse.data = "0";
                resultResponse.message = "Product not found";
                resultResponse.status = false;
            }
            else
            {
                resultResponse.data = "1";
                resultResponse.message = "Product deleted successfully";
                resultResponse.status = true;
            }

            return resultResponse;

        }


        public async Task<ServiceResponse<string>> updateProduct(ProductDTO productDTO, int product_id)
        {
            try
            {
                var resultResponse = new ServiceResponse<string>();

                var existProductId = await iproduct.getProductById(product_id);

                if (existProductId == null)
                {
                    resultResponse.data = "0";
                    resultResponse.message = "Invalid product_id!";
                    resultResponse.status = false;
                    return resultResponse;
                }
                else
                {

                    string? imageURL = null;
                    if (productDTO.product_image != null)
                    {
                        imageURL = await cloudinaryService.uploadImages(productDTO.product_image);
                        if (imageURL == null)
                        {
                            resultResponse.data = "0";
                            resultResponse.message = "Image upload failed.";
                            resultResponse.status = false;
                            return resultResponse;
                        }
                    }

                    var updatedProduct = new Product
                    {
                        product_name = productDTO.product_name,
                        product_description = productDTO.product_description,
                        product_price = productDTO.product_price,
                        product_image = imageURL,
                        product_isActive = productDTO.product_isActive,
                        category_id = productDTO.category_id,

                    };

                    await iproduct.updateProduct(updatedProduct, product_id);

                    resultResponse.data = "1";
                    resultResponse.message = "Product updated successfully.";
                    resultResponse.status = true;

                    return resultResponse;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR in ProductService in updateProduct method: " + ex.Message);
                throw;
            }
        }

        public async Task<ProductDTO?> getProductById(int product_id)
        {
            var product = await iproduct.getProductById(product_id);

            if (product == null)
                return null;

            return new ProductDTO
            {
                product_id = product.product_id,
                product_name = product.product_name,
                product_description = product.product_description,
                product_price = product.product_price,
                product_imageURL = product.product_image,
                product_isActive = product.product_isActive,
                category_id = product.category_id,
                category_name = product.Category?.category_name
            };
        }

        public async Task<List<ProductDTO>> viewProduct()
        {
            var result = await iproduct.viewProduct(); // fetch from repo

            return result.Select(p => new ProductDTO
            {
                product_id = p.product_id,
                product_name = p.product_name,
                product_description = p.product_description,
                product_price = p.product_price,
                product_imageURL = p.product_image,
                product_isActive = p.product_isActive,
                category_name = p.Category?.category_name
            }).ToList();
        }
    }
}
















