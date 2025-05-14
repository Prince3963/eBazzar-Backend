using System.Linq;
using eBazzar.DTO;
using eBazzar.Model;
using eBazzar.Repository;

namespace eBazzar.Services
{
    public class CategoryServices : ICategoryService
    {
        private readonly ICategoryRepo icategoryRepo;
        public CategoryServices(ICategoryRepo icategoryRepo)
        {
            this.icategoryRepo = icategoryRepo;
        }
        public async Task<CategoryDTO> addCategory(CategoryDTO categoryDTO)
        {
            var result = new Category()
            {
                category_id = categoryDTO.category_id,
                category_name = categoryDTO.category_name,
                category_description = categoryDTO.category_description

            };

            await icategoryRepo.addCategory(result);
            return new CategoryDTO
            {
                category_id = result.category_id,
                category_name = result.category_name,
                category_description = result.category_description
            };
        }

        public async Task<List<CategoryDTO>> displayCategory()
        {
            var result = await icategoryRepo.displayCategory();

            return result.Select(c => new CategoryDTO
            {
                category_id = c.category_id,
                category_name = c.category_name,
                category_description = c.category_description,
            }).ToList();
        }

        public async Task<CategoryDTO> updateCategory(CategoryDTO categoryDTO)
        {
            //throw new NotImplementedException();
            var result = new Category()
            {
                category_id = categoryDTO.category_id,
                category_name = categoryDTO.category_name,
                category_description = categoryDTO.category_description
            };

            var updateCategory = await icategoryRepo.updateCategory(result);

            return new CategoryDTO
            {
                category_id = result.category_id,
                category_name = result.category_name,
                category_description = result.category_description
            };
        }
    }
}
