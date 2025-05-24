using BusinessLogicLayer.IInterfaces;
using DataAccessLayer.Models;
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
        private readonly ILogger<CategoryController> _logger;

        public CategoryController(ICategoryService categoryService,
                                ILogger<CategoryController> logger)
        {
            _categoryService = categoryService;
            _logger = logger;
        }

        [HttpGet("All", Name = "GetAllCategories")]
        [ProducesResponseType(200, Type = typeof(Category))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(Category))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(Category))]
        public async Task<IActionResult> Get()
        {
            try
            {
                _logger.LogInformation("GetStudents method started executing !");
                var categories = await _categoryService.GetAllCategoriesAsync();
                _logger.LogInformation("All Categories successfully fetched !");
                return Ok(categories);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error ocurred while fetching all categories !");
                return StatusCode(500, new {message = "serverda xatolik yuz berdi !", detail = ex.Message});
            }
        }

        [HttpPost("post", Name = "AddingCategory")]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(Category))]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(Category))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(Category))]
        public async Task<IActionResult> Post([FromBody]AddCategoryDto addCategoryDto)
        {
            try
            {
                _logger.LogInformation("Cateogry Post method started ! ");
                if (!ModelState.IsValid)
                {
                    _logger.LogError("Invalid modelstate for AddCategory! ");
                    return BadRequest(ModelState);
                }
                else
                {
                    var result = await _categoryService.AddCategoryAsync(addCategoryDto);
                    _logger.LogInformation("Category sucessfully added !");
                    return CreatedAtAction(
                        nameof(GetById), 
                        new { id = result.Id}, 
                        addCategoryDto);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occured while adding category !");
                return StatusCode(500, new {message = "serverda xatolik yuz berdi !", detail = ex.Message});
            }

        }


        [HttpGet("{id:int:range(1, 100)}", Name = "GetStudentById")] //{string:alpha}
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Category))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(Category))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(Category))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(Category))]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                _logger.LogInformation("GetCatgoryById started !");
                if (id <= 0)
                {
                    _logger.LogError("Parameter Id is less then 0");
                    // return 400 badrequest - client error
                    return BadRequest("Id 0 dan katta bo'lishi kerak !");
                }

                _logger.LogInformation($"Catgory with {id} fetched !");
                var category = await _categoryService.GetCategoryByIdAsync(id);
                return Ok(category);
            }
            catch (KeyNotFoundException ex)
            {
                _logger.LogError(ex, $"Category with {id} Not found ");
                return NotFound(ex.Message + $"{id} dagi cateogry topilmadi");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Server error occured while fetching category with {id}");
                return StatusCode(500, new { message = "serverda xatolik yuz berdi !", detail = ex.Message });
            }

        }

        [HttpPut("update", Name = "UpdateCategory")]
        [ProducesResponseType(StatusCodes.Status200OK,  Type = typeof(Category))]
        [ProducesResponseType(StatusCodes.Status400BadRequest,  Type = typeof(Category))]
        [ProducesResponseType(StatusCodes.Status404NotFound,  Type = typeof(Category))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError,  Type = typeof(Category))]

        public async Task<IActionResult> Put(UpdateCategoryDto updateCategoryDto)
        {
            try
            {
                _logger.LogInformation("Put Category method started !");
                if (!ModelState.IsValid)
                {
                    _logger.LogError("IsValid model given while Updating category !");
                    return BadRequest(ModelState);
                }
                
                
                await _categoryService.UpdateCategoryAsync(updateCategoryDto);
                _logger.LogInformation("Category updated successfully !");
                return Ok("Updated !");
            }
            catch (KeyNotFoundException ex)
            {
                _logger.LogError(ex, $"Category with {updateCategoryDto.Id} not found !");
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Server error occured while updating category !");
                return StatusCode(500, new { message = "Serverda qandaydir xatolik sodir bo'ldi !", details = ex.Message });
            }
        }

        [HttpDelete("{id:int:min(1):max(1000)}", Name = "DeleteStudentById")]
        [ProducesResponseType(StatusCodes.Status200OK, Type=typeof(Category))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type=typeof(Category))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type=typeof(Category))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type=typeof(Category))]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                _logger.LogTrace("Trace method started !");
                _logger.LogDebug("Debug method started !");
                _logger.LogInformation("Information method started !");
                _logger.LogWarning("Warning method started !");
                _logger.LogError("Error method started !");
                _logger.LogCritical("Critical    method started !");

                await _categoryService.DeleteCategoryAsync(id);
                _logger.LogInformation($"Category with Id = {id} deleted successfully !");
                return Ok("Deleted !");
            }
            catch (ArgumentNullException ex)
            {
                _logger.LogError(ex, "Argemnt Null exception occrued while Deleting cateogry !");
                return BadRequest(ex.Message);
            }
            catch (KeyNotFoundException ex)
            {
                _logger.LogError(ex, $"Category not found with {id} deleting category !");
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occured while Deleting cateogry !");
                return StatusCode(500, new {message = "Serverda qandaydir xatolik yuz berdi !", details = ex.Message});
            }
        }

        [HttpGet("withproducts", Name = "GetStudentsWithProducts")]
        [ProducesResponseType(200, Type = typeof(Category))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(Category))]
        public async Task<IActionResult> GetWithProducts()
        {
            try
            {
                _logger.LogInformation("GetCategoryWithproducts method started !");
                var caregories = await _categoryService.GetCategoryWithProducts();
                _logger.LogInformation("Categories fetched successfully !");
                return Ok(caregories);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error ocurred while getting categories !");
                return StatusCode(500, new { message = "serverda xatolik yuz berdi !", detail = ex.Message });
            }
        }

        [HttpGet("withproduct", Name = "GetStudentWithProductsById")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Category))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(Category))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(Category))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(Category))]
        public async Task<IActionResult> GetCategoryWithProduct(int id)
        {
            try
            {
                _logger.LogInformation("GetCategoryWithproduct method started ");
                var category = await _categoryService.GetCategoryWithProduct(id);
                _logger.LogInformation("CategiresWithProducts fetched successfully !");
                return Ok(category);
            }
            catch (ArgumentNullException ex)
            {
                _logger.LogError(ex, "Argument passed less then 0");
                return BadRequest(ex.Message);
            }
            catch (KeyNotFoundException ex)
            {
                _logger.LogError(ex, $"Category with {id} not found");
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occured while fetching categieswithproducts !");
                return StatusCode(500, new { message = "serverda xatolik yuz berdi !", detail = ex.Message });
            }
        }

    }
}
