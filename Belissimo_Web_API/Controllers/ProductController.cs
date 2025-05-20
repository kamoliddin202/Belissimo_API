using BusinessLogicLayer.IInterfaces;
using DTOs.ProductDtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Belissimo_Web_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _product;

        public ProductController(IProductService product)
        {
            _product = product;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var products = await _product.GetAllProductsAsync();
            return Ok(products);    
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var product = await _product.GetProductByIdAsync(id);
                return Ok(product);
            }
            catch (KeyNotFoundException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(AddProductDo addProductDo)
        {
            await _product.AddProductAsync(addProductDo);
            return Created();
        }

        [HttpPut]
        public async Task<IActionResult> Put(UpdateProductDto updateProductDto)
        {
            await _product.UpdateProductAsync(updateProductDto);
            return Ok("Updated !");
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _product.DeleteProductAsync(id);
            return Ok("Deleted !");
        }

        [HttpGet]
        [Route("withOrderItems")]
        public async Task<IActionResult> GetWithOrdetItems()
        {
            var products = await _product.GetProductWithOrderItemsAsync();
            return Ok(products);
        }
    }
}
