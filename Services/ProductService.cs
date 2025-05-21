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
                    //category_id = productDTO.category_id
                    //Category = productDTO.category_name
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

        public Task<ProductDTO> deleteProduct(ProductDTO productDTO)
        {
            throw new NotImplementedException();
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
                //category_id = p.category_id,
                category_name = p.Category?.category_name
            }).ToList();
        }
    }
}








//public async Task<ProductDTO> deleteProduct(ProductDTO productDTO)
//{
//    try
//    {
//         var response = 
//    }
//var product = new Product
//{
//    product_id = productDTO.product_id ?? 0, // ensure id is present
//    product_name = productDTO.product_name,
//    product_description = productDTO.product_description,
//    product_price = productDTO.product_price,
//    product_image = productDTO.product_image,
//    product_isActive = productDTO.product_isActive
//};

//var deleteProduct = await iproduct.deleteProduct(product);
//return new ProductDTO
//{
//    product_id = deleteProduct.product_id
//};
//} 







    