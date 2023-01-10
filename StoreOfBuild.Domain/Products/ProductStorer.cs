using StoreOfBuild.Domain.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreOfBuild.Domain.Products
{
    public class ProductStorer
    {
        private readonly IRepository<Product> _productRepository;
        private readonly IRepository<Category> _categoryRepository;

        public ProductStorer(IRepository<Product> ProductRepository, IRepository<Category> CategoryRepository) 
        {
            _productRepository = ProductRepository;
            _categoryRepository = CategoryRepository;
        }


        public void Store(ProductDto productDto)
        {
            var category = _categoryRepository.GetById(productDto.CategoryId);
            DomainException.When(category == null, "Categoria não existe");

            var product = _productRepository.GetById(productDto.Id);
            if (product == null)
            {
                product = new Product(productDto.Name, category, product.Price, productDto.StorckQuantity);
                _productRepository.Save(product);
            }

            else
                product.Update(productDto.Name, category, product.Price, productDto.StorckQuantity);
        }

    }
}
