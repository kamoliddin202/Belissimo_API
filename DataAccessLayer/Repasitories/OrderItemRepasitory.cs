using DataAccessLayer.Data;
using DataAccessLayer.Interfaces;
using DataAccessLayer.Models;

namespace DataAccessLayer.Repasitories
{
    public class OrderItemRepasitory : Repasitory<OrderItems>, IOrderItemInterface
    {
        public OrderItemRepasitory(AppDbContext appDbContext) : base(appDbContext)
        {
        }
    }
}
