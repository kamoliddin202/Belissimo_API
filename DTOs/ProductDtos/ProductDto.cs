using DataAccessLayer.Models;

namespace DTOs.ProductDtos
{
    public class ProductDto : BaseEntity
    {
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public int CategoryId { get; set; }

        public ICollection<OrderItems> OrderItems { get; set; }
    }
}
