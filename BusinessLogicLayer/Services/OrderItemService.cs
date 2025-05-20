using BusinessLogicLayer.IInterfaces;
using DTOs.OrderItemDtos;

namespace BusinessLogicLayer.Services
{
    public class OrderItemService : IOrderItemService
    {
        public Task<IEnumerable<OrderItemDto>> GetAllOrderItemsAsync()
        {
            throw new NotImplementedException();
        }
    }
}
