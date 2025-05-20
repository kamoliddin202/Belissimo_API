using BusinessLogicLayer.IInterfaces;
using DTOs.CategoryDtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Belissimo_Web_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var categories = await _categoryService.GetAllCategoriesAsync();
            return Ok(categories);  
        }

        [HttpPost]
        public async Task<IActionResult> Post(AddCategoryDto addCategoryDto)
        {
            await _categoryService.AddCategoryAsync(addCategoryDto);
            return Created();
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var category = await _categoryService.GetCategoryByIdAsync(id);
            return Ok(category);
        }

        [HttpPut]
        public async Task<IActionResult> Put(UpdateCategoryDto updateCategoryDto)
        {
            await _categoryService.UpdateCategoryAsync(updateCategoryDto);
            return Ok("Updated !");
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _categoryService.DeleteCategoryAsync(id);
            return Ok("Deleted !");
        }

        [HttpGet]
        [Route("withproducts")]
        public async Task<IActionResult> GetWithProducts()
        {
            var caregories = await _categoryService.GetCategoryWithProducts();
            return Ok(caregories);
        }

        [HttpGet]
        [Route("withproduct")]
        public async Task<IActionResult> GetCategoryWithProduct(int id)
        {
            var category = await _categoryService.GetCategoryWithProduct(id);
            return Ok(category);
        }

    }
}
