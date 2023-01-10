using StoreOfBuild.Domain.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreOfBuild.Domain.Dtos
{
    public class ProductDto
    {
        public int Id { get; private set; }

        public string Name { get; private set; }

        public int CategoryId { get; private set; }

        public decimal Price { get; private set; }

        public int StorckQuantity { get; private set; }
    }
}
