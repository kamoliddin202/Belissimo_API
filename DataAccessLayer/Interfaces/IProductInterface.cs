using DataAccessLayer.IRepasitory;
using DataAccessLayer.Models;

namespace DataAccessLayer.Interfaces
{
    public interface IProductInterface : IRepasitory<Product>
    {
        Task<IEnumerable<Product>> GetAllProductsWithOrderItems();
    }
}
