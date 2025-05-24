using DataAccessLayer.Models;

namespace DTOs.OrderDtos
{
    public class UpdateOrderDto : BaseEntity
    {
        public int TotalPrice { get; set; }
        public int OrderType { get; set; }
        public int IsNow { get; set; }
        public int Time { get; set; }
        public string Comment { get; set; }
        public int Status { get; set; }
        public string UserId { get; set; }
        public int PromocodeId { get; set; }
    }
}
