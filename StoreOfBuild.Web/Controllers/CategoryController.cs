using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StoreOfBuild.Domain;
using StoreOfBuild.Domain.Products;
using StoreOfBuild.Web.ViewModel;

namespace StoreOfBuild.Web.Controllers
{
    //classe de aplicação
    [Authorize]
    public class CategoryController : Controller
    {

        private readonly CategoryStore _categoryStore;
        private readonly IRepository<Category> _categoryRepository;

        public CategoryController(CategoryStore categoryStore, IRepository<Category> repository)
        {
            _categoryRepository = repository;
            _categoryStore = categoryStore;
        }

        public IActionResult Index()
        {
            var categories = _categoryRepository.GetAll();
            var viewModel = categories.Select(c => new CategoryViewModel { Id = c.Id, Name = c.Name });

            return View(viewModel);
        }


        public IActionResult CreateOrEdit(int Id)
        {
            if (Id > 0)
            {
                var category = _categoryRepository.GetById(Id);
                var categoryViewModel = new CategoryViewModel { Id = category.Id, Name = category.Name };
                return View(categoryViewModel);
            }
            else
                return View();
        }


        [HttpPost]
        public IActionResult CreateOrEdit(CategoryViewModel viewModel)
        {
            _categoryStore.Store(viewModel.Name, viewModel.Id);
            return RedirectToAction("Index");
        }
    }
}