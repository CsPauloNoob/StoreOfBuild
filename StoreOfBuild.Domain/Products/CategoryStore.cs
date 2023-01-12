using StoreOfBuild.Domain.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreOfBuild.Domain.Products
{
    //classe de servico
    public class CategoryStore
    {
        private readonly IRepository<Category> _categoryRepository; //repositorio 


        public CategoryStore(IRepository<Category> categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }


        public void Store(CategoryDto categoryDto)
        {
            var category = _categoryRepository.GetById(categoryDto.Id);

            if(category == null)
            {
                category = new Category(categoryDto.Name);
                _categoryRepository.Save(category);
            }
        }
    }
}