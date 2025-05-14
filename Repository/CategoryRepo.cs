using eBazzar.DBcontext;
using eBazzar.Model;
using Microsoft.EntityFrameworkCore;

namespace eBazzar.Repository
{
    public class CategoryRepo : ICategoryRepo
    {
        private readonly AppDBContext dBContext;
        public CategoryRepo(AppDBContext dBContext)
        {
            this.dBContext = dBContext;
        }
        public async Task<Category> addCategory(Category category)
        {
            await dBContext.AddAsync(category);
            await dBContext.SaveChangesAsync();
            return category;
        }

        //public async Task<Category> deleteCategory(Category category)
        //{
        //    await dBContext.Remove();
        //}

        public async Task<List<Category>> displayCategory()
        {
            return await dBContext.categories.ToListAsync();
        }

        public async Task<Category> updateCategory(Category category)
        {
            var result = await dBContext.categories.FindAsync(category.category_id);

            //result.category_id = category.category_id;
            result.category_name = category.category_name;
            result.category_description = category.category_description;

            await dBContext.SaveChangesAsync();
            return category;
        }
    }
}
