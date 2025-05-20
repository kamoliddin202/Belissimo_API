using DTOs.OrderDtos;

namespace BusinessLogicLayer.IInterfaces
{
    public interface IOrderService
    {
        Task<IEnumerable<OrderDto>> GetAllOrdersAsync();
        Task<OrderDto> GetOrderByIdAsync(int id);
        Task AddOrderAsync(AddOrderDto addOrderDto);
        Task UpdateOrderAync(UpdateOrderDto updateOrderDto);
        Task DeleteOrderAsync(int id);

    }
}
