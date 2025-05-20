using DataAccessLayer.Models;
using DTOs.ProductDtos;

namespace DTOs.CategoryDtos
{
    public class CategoryDto : BaseEntity
    {
        public string Name { get; set; }
        public ICollection<ProductDto> Products { get; set; }
    }
}
