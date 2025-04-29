namespace DataAccessLayer.Models
{
    public class Order : BaseEntity
    {
        public int TotalPrice { get; set; }
        public string UserId { get; set; }
        public User User { get; set; }
        public int OrderType { get; set; }
        public int IsNow { get; set; }
        public int Time { get; set; }
        public string Comment { get; set; }
        public int Status { get; set; }
        public int PromocodeId { get; set; }
        public Promocode Promocode { get; set; }
        public ICollection<OrderItems> OrderItems { get; set; }
    }
}
