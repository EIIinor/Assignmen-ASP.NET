using Assignmen_ASP.NET.Contexts;
using Assignmen_ASP.NET.Services;
using Assignmen_ASP.NET.ViewModels;
using Microsoft.AspNetCore.Mvc;


namespace Assignmen_ASP.NET.Controllers;

public class ProductsController : Controller
{

    private readonly ProductService _productService;
    private readonly DataContext _dataContext;
    private readonly TagService _tagService;
    private readonly CategoryService _categoryService;

    public ProductsController(ProductService productService, DataContext dataContext, TagService tagService, CategoryService categoryService)
    {
        _productService = productService;
        _dataContext = dataContext;
        _tagService = tagService;
        _categoryService = categoryService;
    }





    public async Task<IActionResult> Index()
    {
        var viewModel = new ProductsIndexViewModel
        {
            Products = await _productService.GetAllAsync()

            //All = new GridCollectionViewModel
            //{
            //    Title = "All Products",
            //    Categories = new List<string> { "All", "Mobile", "Computers" }
            //}
        };
        return View(viewModel);
    }



    public async Task<IActionResult> Register()
    {
        ViewBag.Tags = await _tagService.GetTagsAsync();
        ViewBag.Categories = await _categoryService.GetCategoriesAsync();
        return View();
    }


    [HttpPost]
    public async Task<IActionResult> Register(ProductRegisterViewModel viewModel, string[] tags, string[] categories)
    {
        if (ModelState.IsValid)
        {
            var product = await _productService.CreateAsync(viewModel);              
            
            await _productService.AddProductTagsAsync(viewModel, tags);
            await _productService.AddProductCategoriesAsync(viewModel, categories);

            if (product != null)
            {
                if (viewModel.Image != null)
                    await _productService.UploadImageAsync(product, viewModel.Image);

                return RedirectToAction("Index", "Products");
            }

            ModelState.AddModelError("", "Something went wrong, go get coffee");
        }

        ViewBag.Tags = await _tagService.GetTagsAsync(tags);
        ViewBag.Categories = await _categoryService.GetCategoriesAsync(categories);
        return View(viewModel);
    }





    public async Task<IActionResult> Details(string articleNumber)
    {
        var product = await _productService.GetProductByArticleNumberAsync(articleNumber);

        if (product == null)
        {
            return NotFound();
        }

        var viewModel = new ProductDetailsViewModel
        {
            Product = product
        };

        return View(viewModel);
    }

}
