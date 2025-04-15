using AutoMapper;
using Bookstore.Models;
using Bookstore.Models.DTOs.Category;
using Bookstore.Repositories;
using Microsoft.AspNetCore.Http.HttpResults;

namespace Bookstore.Services.CategoryService
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public CategoryService(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<int> CreateCategoryAsync(CreateCategory_DTO newCategory)
        {
            var category = _mapper.Map<Category>(newCategory);

           return await _categoryRepository.AddAsync(category);

        }

        public async Task<bool> DeleteCategoryAsync(int id)
        {
            return await _categoryRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<Category_DTO>> GetAllCategoriesAsync()
        {
            List<Category_DTO> categories = new List<Category_DTO>();
            var fetchedCategories = await _categoryRepository.GetAllAsync();
            _mapper.Map(fetchedCategories, categories);
            return categories;
        }

        public async Task<Category_DTO> GetCategoryByIdAsync(int id)
        {
            var category = await _categoryRepository.FindByIdAsync(id);
         
            return _mapper.Map<Category_DTO>(category);
        }

        public async Task<bool> UpdateCategoryAsync(UpdateCategory_DTO updatedCategory)
        {
            var category = _mapper.Map<Category>(updatedCategory);
            return await _categoryRepository.UpdateAsync(category);
        }
    }
}
