using Assignmen_ASP.NET.Services;
using Assignmen_ASP.NET.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Assignmen_ASP.NET.Controllers;


[Authorize(Roles = "Admin")]
public class AdminController : Controller
{
    private readonly AuthService _authService;
    private readonly ProductService _productService;
    private readonly ContactFormService _contactFormService;

    public AdminController(AuthService authService, ProductService productService, ContactFormService contactFormService)
    {
        _authService = authService;
        _productService = productService;
        _contactFormService = contactFormService;
    }



    public IActionResult Index()
    {
        return View();
    }



    public async Task<IActionResult> Users()
    {
        var users = await _authService.GetAllUsersAsync();
        return View(users);
    }


    public IActionResult AddUser()
    {
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> AddUser(UserRegisterViewModel userRegisterViewModel)
    {
        if (ModelState.IsValid)
        {
            if (await _authService.RegisterUserAsync(userRegisterViewModel))
                return RedirectToAction("Users");

            ModelState.AddModelError("", "A user with the same email already exists");
        }
        return View(userRegisterViewModel);
    }



    public async Task<IActionResult> EditUser(string id)
    {
        var (user, address) = await _authService.GetUserWithIdAsync(id);

        var viewModel = new UserRegisterViewModel
        {
            User = user,
            Address = address
        };

        return View(viewModel);
    }





    public async Task<IActionResult> Products()
    {
        var viewModel = new ProductsIndexViewModel
        {
            Products = await _productService.GetAllAsync()
        };
       
        return View(viewModel);
    }


    public async Task<IActionResult> Comments()
    {
        var viewModel = new ContactsIndexViewModel
        {
            Comments = await _contactFormService.GetAllASync(),
            ContactFormService = _contactFormService
        };

        return View(viewModel);
    }
}
