using Assignmen_ASP.NET.Contexts;
using Assignmen_ASP.NET.Models.Entities;
using Assignmen_ASP.NET.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Assignmen_ASP.NET.Controllers;

public class AccountController : Controller
{
    private readonly DataContext _context;

    public AccountController(DataContext context)
    {
        _context = context;
    }




    public IActionResult Logout()
    {
        return View();
    }





    public IActionResult Login()
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
            try
            {
                if (await _userService.UserExist(x => x.Email == registerViewModel.Email))
                {

                }

                UserEntity userEntity = userRegisterViewModel;
                ProfileEntity profileEntity = userRegisterViewModel;

                _context.Users.Add(userEntity);
                await _context.SaveChangesAsync();

                profileEntity.UserId = userEntity.Id;
                _context.Profiles.Add(profileEntity);
                await _context.SaveChangesAsync();


                return RedirectToAction("Index", "Home");
            }
            catch
            {
                ModelState.AddModelError("", "Something went wrong");
            }
           

            //if (await _userService.UserExist(x => x.Email == registerViewModel.Email))
            //{
            //    ModelState.AddModelError("", "Användare finns redan");
            //}
            //else
            //{
            //    if (await _userService.RegisterAsync(registerViewModel))
            //        return RedirectToAction("Index", "Home");
            //    else
            //        ModelState.AddModelError("", "Något gick fel");
            //}
        }
        return View(userRegisterViewModel);
    }






    public IActionResult MyAccount()
    {
        return View();
    }
}
