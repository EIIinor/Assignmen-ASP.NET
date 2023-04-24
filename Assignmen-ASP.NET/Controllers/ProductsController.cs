using Assignmen_ASP.NET.Services;
using Assignmen_ASP.NET.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Assignmen_ASP.NET.Controllers;

public class ProductsController : Controller
{

    //private readonly ProductService _productService;

    //public ProductsController(ProductService productService)
    //{
    //    _productService = productService;
    //}





    //public IActionResult Index()
    //{
    //    var viewModel = new ProductsIndexViewModel
    //    {
    //        All = new GridCollectionViewModel
    //        {
    //            Title = "All Products",
    //            Categories = new List<string> { "All", "Mobile", "Computers" }
    //        }
    //    };
    //    return View(viewModel);
    //}



    //public IActionResult Register()
    //{
    //    return View();
    //}

    //[HttpPost]
    //public async Task<IActionResult> Register(ProductRegisterViewModel productRegisterViewModel)
    //{
    //    if (ModelState.IsValid)
    //    {
    //        if (await _productService.CreateAsync(productRegisterViewModel))
    //            return RedirectToAction("Index", "Products");

    //        ModelState.AddModelError("", "Something went wrong");
    //    }

    //    return View();
    //}
}
