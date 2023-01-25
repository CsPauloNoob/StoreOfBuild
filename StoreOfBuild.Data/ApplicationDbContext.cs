using Microsoft.EntityFrameworkCore;
using StoreOfBuild.Domain.Products;
using StoreOfBuild.Domain.Sale;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using StoreOfBuild.Data.Identity;

namespace StoreOfBuild.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<Sale> Sales{get; set;}
    }
}