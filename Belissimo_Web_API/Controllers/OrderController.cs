using BusinessLogicLayer.IInterfaces;
using DataAccessLayer.Models;
using DTOs.OrderDtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Belissimo_Web_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet("orders", Name = "orders")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetOrders()
        {
            try
            {
                var orders = await _orderService.GetAllOrdersAsync();
                return Ok(orders);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "serverda xatolik yuz berdi !", detail = ex.Message });
            }
        }

        [HttpGet("id:{int}", Name = "GetOrderById")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Order))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(Order))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(Order))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(Order))]
        public async Task<IActionResult> GetOrderByIdAsync(int id)
        {
            try
            {
                if (id <= 0)
                    return BadRequest();

                var order = await _orderService.GetOrderByIdAsync(id);
                return Ok(order);
            }
            catch (ArgumentNullException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "serverda xatolik yuz berdi !", detail = ex.Message });
            }

        }

        [HttpPost("post", Name = "Create Order")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Order))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(Order))]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(Order))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(Order))]
        public async Task<IActionResult> PostOrder([FromBody]AddOrderDto addOrderDto)
        {
            try
            {
                if(!ModelState.IsValid)
                    return BadRequest();

                var order = await _orderService.AddOrderAsync(addOrderDto);
                return CreatedAtAction(nameof(GetOrderByIdAsync),
                                        new { Id = order.Id },
                                        addOrderDto);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new {message = "Serverda xatolik yuz berdi !", detail = ex.Message });   
            }
        }

        [HttpPut("update", Name = "Update order")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Order))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(Order))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(Order))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(Order))]
        public async Task<IActionResult> UpdateOrder(UpdateOrderDto updateOrderDto)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest();

                await _orderService.UpdateOrderAync(updateOrderDto);
                return Ok("Updated ");
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new {message = "Serverda qandaydir xatolik sodir bo'ldi !", detail = ex.Message});
            }
        }

        [HttpDelete("int:{int}", Name = "Delete Order")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Order))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(Order))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(Order))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(Order))]
        public async Task<IActionResult> DeleteOrder(int id)
        {
            try
            {
                await _orderService.DeleteOrderAsync(id);
                return Ok("Deleted  !");
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (ArgumentNullException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new {message = "Serverda qandaydir xatolik sodir bo'ldi !", detail = ex.Message});
            }
        }

    }
}
