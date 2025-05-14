using eBazzar.Model;

namespace eBazzar.Repository
{
    public interface ICategoryRepo
    {
        Task<Category> addCategory(Category category);
        Task<Category> updateCategory(Category category);
        //Task<Category> deleteCategory(Category category);
        Task<List<Category>> displayCategory();
    }
}
