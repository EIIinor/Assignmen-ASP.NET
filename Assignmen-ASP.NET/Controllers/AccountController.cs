using Assignmen_ASP.NET.Services;
using Assignmen_ASP.NET.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace Assignmen_ASP.NET.Controllers;

public class AccountController : Controller
{

    private readonly AuthService _authService;

    public AccountController(AuthService authService)
    {
        _authService = authService;
    }


    [Authorize]
    public IActionResult MyAccount()
    {
        return View();
    }



    public IActionResult Register()
    {
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> Register(UserRegisterViewModel userRegisterViewModel, IFormFile ImageFile)
    {
        if (ModelState.IsValid)
        {
            if (await _authService.RegisterUserAsync(userRegisterViewModel, ImageFile))
                return RedirectToAction("Login");

            ModelState.AddModelError("", "A user with the same email already exists");
        }
        return View(userRegisterViewModel);
    }






    public IActionResult Login()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Login(UserLoginViewModel userLoginViewModel)
    {
        if (ModelState.IsValid)
        {
            var result = await _authService.LoginUserAsync(userLoginViewModel);

            if (result)
            {
                if (User.IsInRole("Admin"))
                    return RedirectToAction("Index", "Admin");
                else
                    return RedirectToAction("MyAccount", "Account");
            }

            ModelState.AddModelError("", "Wrong email or password");
        }

        return View(userLoginViewModel);
    }





    [Authorize]
    public async Task<IActionResult> Logout()
    {
        if (await _authService.LogOutUserAsync(User))
            return LocalRedirect("/");

        return RedirectToAction("Index", "Home");
    }



}
