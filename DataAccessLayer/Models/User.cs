using Microsoft.AspNetCore.Identity;

namespace DataAccessLayer.Models
{
    public class User : IdentityUser
    {
        public ICollection<Order> Orders { get; set; }
    }
}
