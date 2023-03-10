using Microsoft.AspNetCore.Mvc;
using StoreOfBuild.Domain.Products;
using StoreOfBuild.Domain.Sale;
using StoreOfBuild.Domain;
using StoreOfBuild.Web.ViewModel;
using Microsoft.AspNetCore.Authorization;

namespace StoreOfBuild.Web.Controllers
{
    [Authorize]
    public class SaleController : Controller
    {
        private readonly SaleFactory _saleFactory;
        private readonly IRepository<Product> _productRepository;


        public SaleController(SaleFactory saleFactory, IRepository<Product> productRepository)
        {
            _saleFactory = saleFactory;
            _productRepository = productRepository;
        }

        public IActionResult Create()
        {
            var products = _productRepository.GetAll();

            var productsViewModel = products.Select(c => new ProductViewModel { Id = c.Id, Name = c.Name });
            return View(new SaleViewModel { Products = productsViewModel });
        }

        [HttpPost]
        public IActionResult Create(SaleViewModel viewModel)
        {
            _saleFactory.Create(viewModel.ClientName, viewModel.ProductId, viewModel.Quantity);
            return Ok();
        }
    }
}
