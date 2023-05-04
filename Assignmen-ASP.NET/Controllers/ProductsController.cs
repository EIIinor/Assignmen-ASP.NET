﻿using Assignmen_ASP.NET.Contexts;
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
            Products = await _productService.GetAllASync()

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
    public async Task<IActionResult> Register(ProductRegisterViewModel productRegisterViewModel, string[] tags)
    {
        if (ModelState.IsValid)
        {
            if (await _productService.CreateAsync(productRegisterViewModel))
            {
                await _productService.AddProductTagsAsync(productRegisterViewModel, tags);
                return RedirectToAction("Index", "Products");
            }
            ModelState.AddModelError("", "Something went wrong, go get coffee");
        }

        ViewBag.Tags = await _tagService.GetTagsAsync(tags);
        ViewBag.Categories = await _categoryService.GetCategoriesAsync();
        return View(productRegisterViewModel);
    }



    public IActionResult Details()
    {
        return View();
    }
}
