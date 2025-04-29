using DataAccessLayer.Models;

namespace DTOs.OrderItemDtos
{
    public class OrderItemDto : BaseEntity
    {
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }
        public int Price { get; set; }
        public int OrderId { get; set; }
        public Order Order { get; set; }
    }
}
