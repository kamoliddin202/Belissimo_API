using DataAccessLayer.IRepasitory;
using DataAccessLayer.Models;

namespace DataAccessLayer.Interfaces
{
    public interface ICategoryInterface : IRepasitory<Category>
    {
        Task<IEnumerable<Category>> GetCategoryWithProducts();
        Task<Category> GetCategoryByIdWithProducts(int id);  
    }
}
