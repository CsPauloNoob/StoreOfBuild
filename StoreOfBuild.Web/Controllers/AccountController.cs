using Microsoft.AspNetCore.Mvc;
using StoreOfBuild.Data.Identity;
using StoreOfBuild.Domain.Account;
using StoreOfBuild.Web.ViewModel;

namespace StoreOfBuild.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAuthentication _authentication;


        public AccountController(IAuthentication authentication)
        {
            _authentication = authentication;
        }


        public IActionResult Login()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            var result = await _authentication.Authenticate(model.Email, model.Password);
            if (result)
                return Redirect("/");
            else
            {
                ModelState.AddModelError(string.Empty, "Credenciais Incorretas");
                return View(model);
            }
        }
    }
}