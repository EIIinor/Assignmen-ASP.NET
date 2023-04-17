using Assignmen_ASP.NET.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Assignmen_ASP.NET.Controllers
{
    public class ProductsController : Controller
    {
        public IActionResult Index()
        {
            var viewModel = new ProductsIndexViewModel
            {
                All = new GridCollectionViewModel
                {
                    Title = "All Products",
                    Categories = new List<string> { "All", "Mobile", "Computers" }
                }
            };
            return View(viewModel);
        }
    }
}
