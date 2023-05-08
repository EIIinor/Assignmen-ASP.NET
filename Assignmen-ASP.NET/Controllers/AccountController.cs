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
    public async Task<IActionResult> Register(UserRegisterViewModel userRegisterViewModel)
    {
        if (ModelState.IsValid)
        {
            if (await _authService.RegisterUserAsync(userRegisterViewModel))
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
            if (await _authService.LoginUserAsync(userLoginViewModel))
                return RedirectToAction("MyAccount");

            ModelState.AddModelError("", "wrong email or password");
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
