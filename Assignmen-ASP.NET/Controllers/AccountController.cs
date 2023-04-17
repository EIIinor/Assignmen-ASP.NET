using Microsoft.AspNetCore.Mvc;

namespace Assignmen_ASP.NET.Controllers
{
    public class AccountController : Controller
    {

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




        public IActionResult MyAccount()
        {
            return View();
        }
    }
}
