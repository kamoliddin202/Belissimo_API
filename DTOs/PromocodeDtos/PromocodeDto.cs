using DataAccessLayer.Models;

namespace DTOs.PromocodeDtos
{
    public class PromocodeDto : BaseEntity
    {
        public int Kod { get; set; }
        public int Amount { get; set; }
        public DateTime ExpireAt { get; set; }
        public ICollection<Order> Orders { get; set; }
    }
}
