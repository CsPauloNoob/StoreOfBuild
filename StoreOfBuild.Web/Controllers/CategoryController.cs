using Microsoft.AspNetCore.Mvc;

namespace StoreOfBuild.Web.Controllers
{
    public class CategoryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }


        public IActionResult CreateOrEdit()
        {
            return View();
        }


        [HttpPost]
        public IActionResult CreateOrEdit(int id)
        {
            return View();
        }
    }
}