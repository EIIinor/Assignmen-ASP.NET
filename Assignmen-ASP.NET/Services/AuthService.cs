using Assignmen_ASP.NET.Models.Identity;
using Assignmen_ASP.NET.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace Assignmen_ASP.NET.Services;

public class AuthService
{
    private readonly UserManager<AppUser> _userManager;
    private readonly AddressService _addressService;
    private readonly SignInManager<AppUser> _signInManager;
    private readonly RoleManager<IdentityRole> _roleManager;




    public AuthService(UserManager<AppUser> userManager, AddressService addressService, SignInManager<AppUser> signInManager, RoleManager<IdentityRole> roleManager)
    {
        _userManager = userManager;
        _addressService = addressService;
        _signInManager = signInManager;
        _roleManager = roleManager;
    }

    public async Task<bool> RegisterUserAsync(UserRegisterViewModel model)
    {
        try
        {
            AppUser appUser = model;
            var roleName = "User";
   

            if (!await _roleManager.Roles.AnyAsync())
            {
                await _roleManager.CreateAsync(new IdentityRole("Admin"));
                await _roleManager.CreateAsync(new IdentityRole("User"));
            }

            roleName = "User";
            if (!await _userManager.Users.AnyAsync())
                roleName = "Admin";

            var result = await _userManager.CreateAsync(appUser, model.Password);
            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(appUser, roleName);

                var addressEntity = await _addressService.GetOrCreateAsync(model);
                if (addressEntity != null)
                {
                    await _addressService.AddAddressAsync(appUser, addressEntity);
                    return true;
                }
            }
            return true;
        }
        catch { return false; }
    }



    public async Task<bool> LoginUserAsync(UserLoginViewModel model)
    {
        var appUser = await _userManager.Users.FirstOrDefaultAsync(x => x.Email == model.Email);
        if (appUser != null)
        {
            var result = await _signInManager.PasswordSignInAsync(appUser, model.Password, model.RememberMe, false);
            return result.Succeeded;
        }
        return false;
    }


    public async Task<bool> LogOutUserAsync(ClaimsPrincipal user)
    {
        await _signInManager.SignOutAsync();
        return _signInManager.IsSignedIn(user);

    }
}
