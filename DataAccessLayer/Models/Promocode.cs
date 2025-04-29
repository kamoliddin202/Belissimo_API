namespace DataAccessLayer.Models
{
    public class Promocode : BaseEntity
    {
        public int Kod { get; set; }
        public int Amount    { get; set; }
        public DateTime ExpireAt { get; set; }
        public ICollection<Order> Orders { get; set; }
    }
}
