using System.ComponentModel.DataAnnotations;
using DataAccessLayer.Models;

namespace DTOs.CategoryDtos
{
    public class AddCategoryDto
    {
        [Required(ErrorMessage = "Category Name is required !")]
        [StringLength(30, ErrorMessage = "harflar soni ikkidan kam va 30 dan ko'p bo'lmasin !"),
         MinLength(2, ErrorMessage = "Eng kamida  2 ta harf kiriting !")]

        public string Name { get; set; }
    }
}
