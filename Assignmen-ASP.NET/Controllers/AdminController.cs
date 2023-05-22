using Assignmen_ASP.NET.Models.Entities;
using Assignmen_ASP.NET.Models.Identity;
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
    private readonly UserManager<AppUser> _userManager;

    public AdminController(AuthService authService, ProductService productService, ContactFormService contactFormService, UserManager<AppUser> userManager)
    {
        _authService = authService;
        _productService = productService;
        _contactFormService = contactFormService;
        _userManager = userManager;
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
    public async Task<IActionResult> AddUser(UserRegisterViewModel userRegisterViewModel, IFormFile ImageFile)
    {
        if (ModelState.IsValid)
        {
            if (await _authService.RegisterUserAsync(userRegisterViewModel, ImageFile))
                return RedirectToAction("Users");

            ModelState.AddModelError("", "A user with the same email already exists");
        }
        return View(userRegisterViewModel);
    }



    public async Task<IActionResult> EditUser(string id)
    {
        var userTuple = await _authService.GetUserWithAddressAndRoleAsync(id);
        if (userTuple.user == null)
        {
            return NotFound();
        }

        var viewModel = new UserEditViewModel
        {
            FirstName = userTuple.user.FirstName,
            LastName = userTuple.user.LastName,
            StreetName = userTuple.address.Address?.StreetName,
            PostalCode = userTuple.address.Address?.PostalCode,
            City = userTuple.address.Address?.City,
            PhoneNumber = userTuple.user.PhoneNumber,
            CompanyName = userTuple.user.CompanyName,
            Email = userTuple.user.Email,
            SelectedRole = userTuple.roles.FirstOrDefault()
        };

        return View(viewModel);
    }
    [HttpPost]
    public async Task<IActionResult> EditUser(UserEditViewModel model)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }

        var userTuple = await _authService.GetUserWithAddressAndRoleAsync(model.Id);
        if (userTuple.user == null)
        {
            return NotFound();
        }

        // Update the user properties
        userTuple.user.FirstName = model.FirstName;
        userTuple.user.LastName = model.LastName;
        // Update other properties

        // Update the user's role
        await _authService.UpdateUserAsync(userTuple.user, model.SelectedRole, userTuple.address);

        return RedirectToAction("Index"); // Redirect to the user list or a success page
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
