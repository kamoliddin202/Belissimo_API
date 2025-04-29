using DataAccessLayer.Data;
using DataAccessLayer.Interfaces;
using DataAccessLayer.Models;

namespace DataAccessLayer.Repasitories
{
    public class ProductRepasitory : Repasitory<Product>, IProductInterface
    {
        public ProductRepasitory(AppDbContext appDbContext) : base(appDbContext)
        {
        }
    }
}
