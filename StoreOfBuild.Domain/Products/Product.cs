using System;

namespace StoreOfBuild.Domain.Products
{
    public class Product : Entity
    {
        public string Name { get; private set; }

        public Category Category { get; private set; }

        public decimal Price { get; private set; }
        
        public int StockQuantity { get; private set; }

        private Product() { }

        public Product(string name, Category category, decimal price, int stockQuantity)
        {
            Validate(name, category, price, stockQuantity);
            SetProperties(name, category, price, stockQuantity);
        }


        public void Update(string name, Category category, decimal price, int stockqtty)
        {
            Validate(name, category, price, stockqtty);
            SetProperties(name, category, price, stockqtty);
        }




        private void Validate(string name, Category category, decimal price, int stockqtty)
        {
            DomainException.When(!string.IsNullOrEmpty(name), "Nome é obrigatório");
            DomainException.When(!(category == null), "Categoria é obrigatório");
            DomainException.When(!(price < 0), "preço é obrigatório");
            DomainException.When(!(stockqtty < 0), "quantidade em estoque é obrigatório");
        }


        private void SetProperties(string name, Category category, decimal price, int stockqtty)
        {
            Name = name;
            Category = category;
            Price = price;
            StockQuantity = stockqtty;
        }
    }
}