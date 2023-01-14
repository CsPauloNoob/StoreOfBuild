using Microsoft.AspNetCore.Mvc;
using StoreOfBuild.Domain.Products;
using StoreOfBuild.Web.ViewModel;

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

        [HttpGet]
        public IActionResult CreateOrEdit()
        {
            return View();
        }


        [HttpPost]
        public IActionResult CreateOrEdit(CategoryViewModel viewModel)
        {
            _categoryStore.Store(viewModel.Name, viewModel.Id);
            return View();
        }
    }
}