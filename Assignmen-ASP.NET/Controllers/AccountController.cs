using Assignmen_ASP.NET.Services;
using Assignmen_ASP.NET.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace Assignmen_ASP.NET.Controllers;

public class AccountController : Controller
{



    private readonly UserService _userService;
    private readonly AuthService _authService;

    public AccountController(UserService userService, AuthService authService)
    {
        _userService = userService;
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
            if (await _authService.RegisterAsync(userRegisterViewModel))
                return RedirectToAction("Login");

            ModelState.AddModelError("", "A user with the same email already exists");
        }
        return View(userRegisterViewModel);


        //if (ModelState.IsValid)
        //{
        //    if (await _userService.UserExist(x => x.Email == userRegisterViewModel.Email))
        //    {
        //        ModelState.AddModelError("", "User already exist");
        //    }
        //    else
        //    {
        //        if (await _userService.RegisterAsync(userRegisterViewModel))
        //            return RedirectToAction("Login", "Account");
        //        else
        //            ModelState.AddModelError("", "Something went wrong");
        //    }
        //}
        //return View(userRegisterViewModel);
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
            if (await _authService.LoginAsync(userLoginViewModel))
                return RedirectToAction("MyAccount");

            ModelState.AddModelError("", "wrong email or password");
        }
        return View(userLoginViewModel);


        //if (ModelState.IsValid)
        //{
        //    if (await _userService.LoginAsync(userLoginViewModel))
        //        return RedirectToAction("Index", "Home");
        //    ModelState.AddModelError("", "Wrong email or password");
        //}
        //return View(userLoginViewModel);
    }




    [Authorize]
    public async Task<IActionResult> Logout()
    {
        if (await _authService.LogOutAsync(User))
            return LocalRedirect("/");

        return RedirectToAction("Index", "Home");
        
    }


}
