using DataAccessLayer.Data;
using DataAccessLayer.Interfaces;
using DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Repasitories
{
    public class CategoryRepasitory : Repasitory<Category>, ICategoryInterface
    {
        private readonly AppDbContext _appDbContext;

        public CategoryRepasitory(AppDbContext appDbContext) : base(appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<Category> GetCategoryByIdWithProducts(int id)
        {
            return await _appDbContext.Categories.Include(c => c.Products).FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<IEnumerable<Category>> GetCategoryWithProducts()
        {
            return await _appDbContext.Categories.Include(c => c.Products).ToListAsync();
        }
    }
}
