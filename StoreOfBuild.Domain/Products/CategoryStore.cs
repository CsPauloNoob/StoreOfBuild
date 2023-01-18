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


        public void Store(string name, int id)
        {
            var category = _categoryRepository.GetById(id);

            if(category == null)
            {
                category = new Category(name);
                _categoryRepository.Save(category);
            }
            else
                category.Update(name);
        }
    }
}