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

        [HttpDelete]
        [Route("deleteProduct")]
        public async Task<IActionResult> deleteProduct(ProductDTO productDTO)
        {
            var result = await iserviceProduct.deleteProduct(productDTO);
            return Ok(result);
        }
    }
}
