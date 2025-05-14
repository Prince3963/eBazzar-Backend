using eBazzar.DTO;

namespace eBazzar.Services
{
    public interface ICategoryService
    {
        Task<CategoryDTO> addCategory(CategoryDTO categoryDTO);
        Task<CategoryDTO> updateCategory(CategoryDTO categoryDTO);
        Task<List<CategoryDTO>> displayCategory();

    }
}
