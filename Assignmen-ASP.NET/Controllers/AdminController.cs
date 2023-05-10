using Assignmen_ASP.NET.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Assignmen_ASP.NET.Controllers;


[Authorize(Roles = "Admin")]
public class AdminController : Controller
{
    private readonly AuthService _authService;

    public AdminController(AuthService authService)
    {
        _authService = authService;
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

    public async Task<IActionResult> Products()
    {
        return View();
    }
}
