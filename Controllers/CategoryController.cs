using eBazzar.DBcontext;
using eBazzar.DTO;
using eBazzar.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eBazzar.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            this.categoryService = categoryService;
        }

        [HttpGet]
        public async Task<IActionResult> viewCategory()
        {
            return Ok(await categoryService.displayCategory());
        }

        [HttpPost]
        public async Task<IActionResult> addCategory([FromForm] CategoryDTO categoryDTO)
        {
            return Ok(await categoryService.addCategory(categoryDTO));
        }

        [HttpPut]
        [Route("updateCategory")]
        public async Task<IActionResult> updateCateggory([FromForm] CategoryDTO categoryDTO)
        {
            var result = await categoryService.updateCategory(categoryDTO);
            return Ok(result);
        }
    }
}
