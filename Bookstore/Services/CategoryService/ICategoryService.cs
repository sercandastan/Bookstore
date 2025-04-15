

using Bookstore.Models.DTOs.Category;

namespace Bookstore.Services.CategoryService
{
    public interface ICategoryService
    {
        public Task<IEnumerable<Category_DTO>> GetAllCategoriesAsync();

        public Task<int> CreateCategoryAsync(CreateCategory_DTO newCategory);

        public Task<bool> UpdateCategoryAsync(UpdateCategory_DTO updatedCategory);

        public Task<Category_DTO> GetCategoryByIdAsync(int id);
        
        public Task<bool> DeleteCategoryAsync(int id);

    }
}
