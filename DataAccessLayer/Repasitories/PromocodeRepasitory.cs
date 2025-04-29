using DataAccessLayer.Data;
using DataAccessLayer.IRepasitory;
using DataAccessLayer.Models;

namespace DataAccessLayer.Repasitories
{
    public class PromocodeRepasitory : Repasitory<Promocode>, IPromocodeInterface
    {
        public PromocodeRepasitory(AppDbContext appDbContext) : base(appDbContext)
        {
        }
    }
}
