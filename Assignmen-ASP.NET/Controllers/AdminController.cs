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
        var (user, userAddress) = await _authService.GetUserWithIdAsync(id);

        //var viewModel = new UserEditViewModel
        //{
        //    User = user,
        //    Address = userAddress != null ? userAddress.Address : new AddressEntity()
        //};

        return View();
    }
    //[HttpPost]
    //public async Task<IActionResult> EditUser(UserEditViewModel viewModel)
    //{
    //    if (ModelState.IsValid)
    //    {
    //        // Get the user to update
    //        var user = await _userManager.FindByIdAsync(viewModel.User.Id);

    //        if (user != null)
    //        {
    //            // Update the user properties
    //            user.FirstName = viewModel.User.FirstName;
    //            user.LastName = viewModel.User.LastName;
    //            user.CompanyName = viewModel.User.CompanyName;
    //            user.Email = viewModel.User.Email;
    //            user.PhoneNumber = viewModel.User.PhoneNumber;

    //            try
    //            {
    //                // Update the user's address
    //                var userAddress = await _authService.GetUserAddressAsync(user.Id);
    //                if (userAddress != null)
    //                {
    //                    userAddress.Address.StreetName = viewModel.Address.StreetName;
    //                    userAddress.Address.PostalCode = viewModel.Address.PostalCode;
    //                    userAddress.Address.City = viewModel.Address.City;

    //                    // Update the user's address and role
    //                    //await _authService.UpdateUserWithAddressAndRoleAsync(user, userAddress, viewModel.SelectedRole);
    //                }

    //                // Save the changes
    //                var result = await _userManager.UpdateAsync(user);
    //                if (result.Succeeded)
    //                {
    //                    // Redirect to a success page or perform other actions
    //                    return RedirectToAction("Users");
    //                }
    //                else
    //                {
    //                    // Handle the update failure
    //                    foreach (var error in result.Errors)
    //                    {
    //                        ModelState.AddModelError("", "Something went wrong");
    //                    }
    //                }
    //            }
    //            catch (Exception)
    //            {
    //                ModelState.AddModelError("", "Failed to update address or role.");
    //            }
    //        }
    //        else
    //        {
    //            ModelState.AddModelError("", "User not found.");
    //        }
    //    }
    //    return View(viewModel);
    //}







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
