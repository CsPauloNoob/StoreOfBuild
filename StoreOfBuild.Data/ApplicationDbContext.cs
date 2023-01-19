using Microsoft.EntityFrameworkCore;
using StoreOfBuild.Domain.Products;
using System;

namespace StoreOfBuild.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Category> Categories { get; set; }
        
        public DbSet<Product> Products { get; set; }
    }
}