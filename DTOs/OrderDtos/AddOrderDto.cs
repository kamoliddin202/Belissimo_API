using System.ComponentModel.DataAnnotations;
using DataAccessLayer.Models;

namespace DTOs.OrderDtos
{
    public class AddOrderDto
    {
        [Required(ErrorMessage = "Total price is required !")]
        public int TotalPrice { get; set; }
        [Required(ErrorMessage = "UserId is required !")]
        public string  UserId { get; set; }
        [Required(ErrorMessage = "OrderType is required !")]
        public int OrderType { get; set; }
        [Required(ErrorMessage = "IsNow is required !")]
        public int IsNow { get; set; }
        [StringLength(1000)]
        [MinLength(2)]
        public string Comment { get; set; }
        [Required(ErrorMessage = "Status code is required !")]
        public int Status { get; set; }
        [Required(ErrorMessage = "Promocode is required !")]
        public int PromocodeId { get; set; }
    }
}
