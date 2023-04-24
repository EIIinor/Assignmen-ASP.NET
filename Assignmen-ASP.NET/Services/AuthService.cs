using Assignmen_ASP.NET.Contexts;
using Assignmen_ASP.NET.Models.Entities;
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

    //private readonly UserManager<IdentityUser> _userManager;
    //private readonly SignInManager<IdentityUser> _signInManager;
    //private readonly RoleManager<IdentityRole> _roleManager;
    //private readonly IdentityContext _identityContext;
    //private readonly SeedService _seedService;

    //public AuthService(UserManager<IdentityUser> userManager, IdentityContext identityContext, SignInManager<IdentityUser> signInManager, SeedService seedService, RoleManager<IdentityRole> roleManager)
    //{
    //    _userManager = userManager;
    //    _identityContext = identityContext;
    //    _signInManager = signInManager;
    //    _seedService = seedService;
    //    _roleManager = roleManager;
    //}

    public AuthService(UserManager<AppUser> userManager, AddressService addressService, SignInManager<AppUser> signInManager)
    {
        _userManager = userManager;
        _addressService = addressService;
        _signInManager = signInManager;
    }

    public async Task<bool> RegisterUserAsync(UserRegisterViewModel model)
    {
        AppUser appUser = model;

        var result =await _userManager.CreateAsync(appUser, model.Password);
        if (result.Succeeded)
        {
            var addressEntity = await _addressService.GetOrCreateAsync(model);
            if (addressEntity != null)
            {
                await _addressService.AddAddressAsync(appUser, addressEntity);
                return true;
            }
        }
        return false;

        //try
        //{
        //    await _seedService.SeedRoles();
        //    var roleName = "user";

        //    if (!await _userManager.Users.AnyAsync())
        //        roleName = "admin";

        //    IdentityUser identityUser = model;
        //    await _userManager.CreateAsync(identityUser, model.Password);

        //    await _userManager.AddToRoleAsync(identityUser, roleName);

        //    UserProfileEntity userProfileEntity = model;
        //    userProfileEntity.UserId = identityUser.Id;

        //    _identityContext.UserProfiles.Add(userProfileEntity);
        //    await _identityContext.SaveChangesAsync();

        //    return true;
        //}
        //catch { return false; }
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

        //try
        //{
        //    var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, false);
        //    return result.Succeeded;
        //}
        //catch { return false; }
    }


    public async Task<bool> LogOutUserAsync(ClaimsPrincipal user)
    {
        await _signInManager.SignOutAsync();
        return _signInManager.IsSignedIn(user);

    }
}
