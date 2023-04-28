using Assignmen_ASP.NET.Contexts;
using Assignmen_ASP.NET.Services;
using Assignmen_ASP.NET.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Assignmen_ASP.NET.Controllers;

public class ProductsController : Controller
{

    private readonly ProductService _productService;
    private readonly DataContext _dataContext;

    public ProductsController(ProductService productService, DataContext dataContext)
    {
        _productService = productService;
        _dataContext = dataContext;
    }





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



    public IActionResult Register()
    {
        var viewModel = new ProductRegisterViewModel(_dataContext.Categories);
        return View(viewModel);
    }

    [HttpPost]
    public async Task<IActionResult> Register(ProductRegisterViewModel productRegisterViewModel)
    {


        if (ModelState.IsValid)
        {
            if (await _productService.CreateAsync(productRegisterViewModel))
                return RedirectToAction("Index", "Products");

            ModelState.AddModelError("", "Something went wrong");
        }

        return View(productRegisterViewModel);
    }



    public IActionResult Details()
    {
        return View();
    }
}
