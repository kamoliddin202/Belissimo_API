using DataAccessLayer.Models;

namespace DTOs.CategoryDtos
{
    public class CategoryDto : BaseEntity
    {
        public string Name { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
