using AutoMapper;
using BusinessLogicLayer.IInterfaces;
using DataAccessLayer.Interfaces;
using DataAccessLayer.Models;
using DTOs.CategoryDtos;
using Microsoft.AspNetCore.Http.HttpResults;

namespace BusinessLogicLayer.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CategoryService(IUnitOfWork unitOfWork, 
                                IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<Category> AddCategoryAsync(AddCategoryDto category)
        {

            var mapped = _mapper.Map<Category>(category);
            await _unitOfWork.CategoryInterface.AddEntityAsync(mapped);
            await _unitOfWork.SaveChangesAsync();
            return mapped;
        }

        public async Task DeleteCategoryAsync(int id)
        {
            if(id <= 0)
                throw new ArgumentNullException(nameof(id));
            
            var category = await _unitOfWork.CategoryInterface.GetEntityByIdAsync(id);
            if(category == null)
                throw new KeyNotFoundException(nameof(category));

            await _unitOfWork.CategoryInterface.DeleteEntityAsyanc(category.Id);
            await _unitOfWork.SaveChangesAsync();   
        }

        public async Task<IEnumerable<CategoryDto>> GetAllCategoriesAsync()
        {
            var categories = await _unitOfWork.CategoryInterface.GetAllEntitiesAsync();
            #region manula mapping
            var result = categories.Select(c => new CategoryDto()
            {
                Name = c.Name,
            });
            #endregion

            return categories.Select(c => _mapper.Map<CategoryDto>(c));
        }

        public async Task<CategoryDto> GetCategoryByIdAsync(int id)
        {
            if (id <= 0)
                throw new ArgumentNullException(nameof(id));

            var category = await _unitOfWork.CategoryInterface.GetEntityByIdAsync(id);
            if(category == null)
                throw new KeyNotFoundException($"Id {id}");

            return _mapper.Map<CategoryDto>(category);
        }

        public async Task<CategoryDto> GetCategoryWithProduct(int id)
        {
            if(id <= 0)
                throw new ArgumentNullException("Id musbat bo'lishi kerak ! " , nameof(id));

            var category = await _unitOfWork.CategoryInterface.GetCategoryByIdWithProducts(id);
            if (category == null)
                throw new KeyNotFoundException($"Category {id} topilmadi !");

            return _mapper.Map<CategoryDto>(category);
        }

        public async Task<IEnumerable<CategoryDto>> GetCategoryWithProducts()
        {

            var categories = await _unitOfWork.CategoryInterface.GetCategoryWithProducts();
            if(categories == null || !categories.Any())
                return Enumerable.Empty<CategoryDto>();

            return categories.Select(c => _mapper.Map<CategoryDto>(c));
        }

        public async Task UpdateCategoryAsync(UpdateCategoryDto updateCategoryDto)
        {
            var category = await _unitOfWork.CategoryInterface.GetEntityByIdAsync(updateCategoryDto.Id);
            if (category == null)
                throw new KeyNotFoundException(nameof(category));

            _mapper.Map(updateCategoryDto, category);
            await _unitOfWork.CategoryInterface.UpdateEntityAsyanc(category);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
