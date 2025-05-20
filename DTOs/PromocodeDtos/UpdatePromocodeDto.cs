using DataAccessLayer.Models;

namespace DTOs.PromocodeDtos
{
    public class UpdatePromocodeDto : BaseEntity
    {
        public int Kod { get; set; }
        public int Amount { get; set; }
    }
}
