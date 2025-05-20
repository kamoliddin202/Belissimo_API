using DataAccessLayer.Data;
using DataAccessLayer.Interfaces;
using DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Repasitories
{
    public class ProductRepasitory : Repasitory<Product>, IProductInterface
    {
        public ProductRepasitory(AppDbContext appDbContext) : base(appDbContext)
        {
        }

        public async Task<IEnumerable<Product>> GetAllProductsWithOrderItems()
        {
            return await _dbContext.Products.Include(c => c.OrderItems).ToListAsync();
        }
    }
}
