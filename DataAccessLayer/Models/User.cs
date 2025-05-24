using Microsoft.AspNetCore.Identity;

namespace DataAccessLayer.Models
{
    public class User : IdentityUser
    {
        public string FullName { get; set; }
        public string Address { get; set; }
        public ICollection<Order> Orders { get; set; }
    }
}
