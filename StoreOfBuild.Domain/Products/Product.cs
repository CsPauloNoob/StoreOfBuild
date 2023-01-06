using System;

namespace StoreOfBuild.Domain.Products
{
    internal class Product
    {
        public int Id { get; private set; }

        public string Name { get; private set; }

        public int CategoryId { get; private set; }

        public Category Category { get; private set; }

        public decimal Price { get; private set; }

        public int StorckQuantity { get; private set; }


        public Product(int id, string name, Category category, decimal price, int stockqtty)
        {
            Validate(name, category, price, stockqtty);
            SetProperties(id, name, category, price, stockqtty);
        }


        public void Update(int id, string name, Category category, decimal price, int stockqtty)
        {
            Validate(name, category, price, stockqtty);
            SetProperties(id, name, category, price, stockqtty);
        }




        private void Validate(string name, Category category, decimal price, int stockqtty)
        {
            DomainException.When(string.IsNullOrEmpty(name), "Nome é obrigatório");
            DomainException.When(category == null, "Categoria é obrigatório");
            DomainException.When(price < 0, "preço é obrigatório");
            DomainException.When(stockqtty < 0, "quantidade em estoque é obrigatório");
        }


        private void SetProperties(int id, string name, Category category, decimal price, int stockqtty)
        {
            Id = id;
            Name = name;
            Category = category;
            Price = price;
            StorckQuantity = stockqtty;
        }
    }
}
