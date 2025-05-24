using DataAccessLayer.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Data
{
    public class AppDbContext : IdentityDbContext<User>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItems> OrderItems { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Promocode> Promocodes { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>()
                .HasMany(p => p.Products)
                .WithOne(c => c.Category)
                .HasForeignKey(f => f.CategoryId);

            modelBuilder.Entity<Order>()
                .HasOne(u => u.User)
                .WithMany(o => o.Orders)
                .HasForeignKey(u => u.UserId);

            modelBuilder.Entity<Order>()
                .HasMany(o => o.OrderItems)
                .WithOne(o => o.Order)
                .HasForeignKey(c =>  c.OrderId);

            modelBuilder.Entity<Product>()
                .HasMany(o => o.OrderItems)
                .WithOne(p => p.Product)
                .HasForeignKey(f => f.ProductId);

            modelBuilder.Entity<Promocode>()
                .HasMany(o => o.Orders)
                .WithOne(p => p.Promocode)
                .HasForeignKey(f => f.PromocodeId);


            base.OnModelCreating(modelBuilder);

            //List<IdentityRole> roles = new List<IdentityRole>
            //{
            //    new IdentityRole
            //    {
            //        Id = "",
            //        Name = "Admin",
            //        NormalizedName = "ADMIN"
            //    },
            //    new IdentityRole
            //    {
            //        Name = "User",
            //        NormalizedName = "USER"
            //    }
            //};
            //modelBuilder.Entity<IdentityRole>().HasData(roles);
        }

    }
}



//ASP.NET Core'da 2 asosiy routing turi mavjud:
//1. Conventional Routing – odatda MVC uchun ishlatiladi.
//2. Attribute Routing – REST API uchun ishlatiladi (eng ko‘p qo‘llaniladi).