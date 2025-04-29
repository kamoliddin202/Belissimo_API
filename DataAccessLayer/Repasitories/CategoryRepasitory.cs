using DataAccessLayer.Data;
using DataAccessLayer.Interfaces;
using DataAccessLayer.Models;

namespace DataAccessLayer.Repasitories
{
    public class CategoryRepasitory : Repasitory<Category>, ICategoryInterface
    {
        public CategoryRepasitory(AppDbContext appDbContext) : base(appDbContext)
        {
        }
    }
}
