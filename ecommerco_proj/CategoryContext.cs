using ecommerco_proj.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ecommerco_proj
{
    public class CategoryContext : IdentityDbContext<AppUser>
    {
        public CategoryContext(DbContextOptions<CategoryContext> options) : base(options)
        {
        }
        public DbSet<Product> products { get; set; }
        public DbSet<Category> categories { get; set; }
        public DbSet<Cart> carts { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            List<IdentityRole> roles = new List<IdentityRole>()
            {
                new IdentityRole
                {
                    Name= "Admin",
                    NormalizedName= "ADMIN",
                },
                new IdentityRole
                {
                    Name= "User",
                    NormalizedName= "USER",
                }
            };
            builder.Entity<IdentityRole>().HasData(roles);
        }

    }
}
