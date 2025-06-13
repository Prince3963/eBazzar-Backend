using eBazzar.DTO;
using eBazzar.Model;
using eBazzar.Repository;
using eBazzar.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eBazzar.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IServiceProduct iserviceProduct;

        public ProductController(IServiceProduct iserviceProduct)
        {
            this.iserviceProduct = iserviceProduct;
        }

        [HttpGet("viewProduct")]
        public async Task<IActionResult> viewProduct()
        {
            return Ok(await iserviceProduct.viewProduct());
        }

        [HttpGet]
        [Route("getProductById/{product_id}")]
        public async Task<IActionResult> getProductById(int product_id)
        {
            var result = await iserviceProduct.getProductById(product_id);

            if (result == null)
            {
                return NotFound(new { message = "Product not found in Controller", status = false });
            }

            return Ok(result);
        }

        [HttpGet]
        [Route("getProductCategory/{category_id}")]
        public async Task<IActionResult> getElectronicCategory(int category_id)
        {
            var result = await iserviceProduct.getElectronicProduct(category_id);
            if (result == null)
            {
                return NotFound(new { message = "Electronic category not found, please check your controller", status = false });   
            }
            return Ok(result);
        }

        


        [HttpPost]
        [Route("addProduct")]
        public async Task<IActionResult> addProduct([FromForm] ProductDTO productDTO)
        {
            var result = await iserviceProduct.addProduct(productDTO);
            return Ok(result);
        }

        [HttpPut]
        [Route("updateProduct/{product_id}")]
        public async Task<IActionResult> updateProduct([FromForm] ProductDTO productDTO, int product_id)
        {
            try
            {
                var result = await iserviceProduct.updateProduct(productDTO, product_id);
                return Ok(result);
            }
            catch (Exception e)
            {
                Console.WriteLine("Please check your product controller" + e);
                return NotFound();
            }
        }

        [HttpPatch]
        [Route("updateProductStatus/{product_id}")]
        public async Task<IActionResult> productStatus(int product_id, [FromBody] ProductStatusDTO productStatusDTO)
        {
            try
            {
                var result = await iserviceProduct.toggleStatus(productStatusDTO, product_id);

                if (result.status == true)
                {
                    return Ok("Product status updated successfully!");
                }
                else
                {
                    return BadRequest(result.message ?? "Failed to update product status!");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error in updating product status: " + e.Message);
                return StatusCode(500, new { message = "Internal Server Error" });
            }
        }

        [HttpDelete]
        [Route("deleteProduct/{product_id}")]
        public async Task<IActionResult> deleteProduct(int product_id)
        {
            var result = await iserviceProduct.deleteProduct(product_id);
            return Ok(result);
        }
    }
}
