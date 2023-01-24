using StoreOfBuild.Domain.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreOfBuild.Domain.Sale
{
    public class SaleItem : Entity
    {
        public Product Product { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public decimal Total { get; set; }

        private SaleItem() { }

        public SaleItem(Product product, int quantity)
        {
            DomainException.When(product == null, "Product is required");
            DomainException.When(quantity < 1, "Quanatity incorrect");

            Product = product;
            Price = Product.Price;
            Quantity = quantity;
            Total = Price * Quantity;
        }
    }
}