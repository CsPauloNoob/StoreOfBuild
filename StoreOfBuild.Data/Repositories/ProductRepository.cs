using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using StoreOfBuild.Domain;
using StoreOfBuild.Domain.Products;

namespace StoreOfBuild.Data.Repositories
{
    public class ProductRepository : Repository<Product>
    {
        public ProductRepository(ApplicationDbContext context) : base(context)
        {

        }

        public override Product GetById(int id)
        {
            var query = _context.Set<Product>().Include(p => p.Category).Where(e => e.Id == id);
            if (query.Any())
                return query.First();
            return null;
        }

        public override IEnumerable<Product> GetAll()
        {
            var query = _context.Set<Product>().Include(p => p.Category);

            return query.Any() ? query.ToList() : new List<Product>();
        }
    }
}