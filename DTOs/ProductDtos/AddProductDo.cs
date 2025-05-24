using System.ComponentModel.DataAnnotations;
using DataAccessLayer.Models;

namespace DTOs.ProductDtos
{
    public class AddProductDo
    {
        [Required(ErrorMessage = "Product name is required !")]
        [StringLength(30, ErrorMessage = "Harflar soni 30 dan oshmasin !")]
        [MinLength(2, ErrorMessage = "Harflar soni 2 dan kam bo'lmasin !")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Url is required !")]
        [StringLength(300, ErrorMessage = "Harflar soni 300 dan oshib ketti !")]
        [MinLength(2, ErrorMessage = "Harflar soni 2 dan katta bo'lishi kerak !")]
        public string ImageUrl { get; set; }

        [StringLength(1000, ErrorMessage = "Harflar soni 1000 dan oshib ketdi !")]
        [MinLength(2, ErrorMessage = "Harflar soni 2 dan ko'p bo'lishi kerak !")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Price is required !")]
        public int Price { get; set; }

        [Required(ErrorMessage = "CategoryId is required ")]
        public int CategoryId { get; set; }
    }
}
