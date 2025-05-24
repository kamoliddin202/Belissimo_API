using DataAccessLayer.Models;
using DTOs.OrderDtos;

namespace BusinessLogicLayer.IInterfaces
{
    public interface IOrderService
    {
        Task<IEnumerable<OrderDto>> GetAllOrdersAsync();
        Task<OrderDto> GetOrderByIdAsync(int id);
        Task<Order> AddOrderAsync(AddOrderDto addOrderDto);
        Task UpdateOrderAync(UpdateOrderDto updateOrderDto);
        Task DeleteOrderAsync(int id);

    }
}
