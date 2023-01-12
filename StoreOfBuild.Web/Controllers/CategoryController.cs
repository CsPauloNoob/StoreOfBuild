using Microsoft.AspNetCore.Mvc;
using StoreOfBuild.Domain;
using StoreOfBuild.Domain.Dtos;
using StoreOfBuild.Domain.Products;

namespace StoreOfBuild.Web.Controllers
{
    //classe de aplicação
    public class CategoryController : Controller
    {

        private readonly CategoryStore _categoryStore; 

        public CategoryController(CategoryStore categoryStore)
        {
            _categoryStore = categoryStore; 
        }

        public IActionResult Index()
        {
            return View();
        }


        public IActionResult CreateOrEdit()
        {
            return View();
        }


        [HttpPost]
        public IActionResult CreateOrEdit(CategoryDto dto)
        {

            return View();
        }
    }
}