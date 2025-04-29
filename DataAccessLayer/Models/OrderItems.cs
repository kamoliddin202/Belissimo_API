namespace DataAccessLayer.Models
{
    public class OrderItems : BaseEntity
    {
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }
        public int Price { get; set; }
        public int OrderId { get; set; }
        public Order Order { get; set; }
    }
}
