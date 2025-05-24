using DataAccessLayer.Models;
using DTOs.CategoryDtos;

namespace BusinessLogicLayer.IInterfaces
{
    public interface ICategoryService 
    {
        public Task<IEnumerable<CategoryDto>> GetAllCategoriesAsync();
        public Task<CategoryDto> GetCategoryByIdAsync(int id);
        public Task<Category> AddCategoryAsync(AddCategoryDto category);
        public Task UpdateCategoryAsync(UpdateCategoryDto updateCategoryDto);
        public Task DeleteCategoryAsync(int id);
        public Task<IEnumerable<CategoryDto>> GetCategoryWithProducts();
        Task<CategoryDto> GetCategoryWithProduct(int id);
    }
}
