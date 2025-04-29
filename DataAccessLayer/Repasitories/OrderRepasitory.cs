using DataAccessLayer.Data;
using DataAccessLayer.Interfaces;
using DataAccessLayer.Models;

namespace DataAccessLayer.Repasitories
{
    public class OrderRepasitory : Repasitory<Order>, IOrderInterface
    {
        public OrderRepasitory(AppDbContext appDbContext) : base(appDbContext)
        {
        }
    }
}
