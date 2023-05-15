using Assignmen_ASP.NET.Helpers.Repositories;
using Assignmen_ASP.NET.Models;
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
    private readonly RoleManager<IdentityRole> _roleManager;
    private readonly UserAddressRepository _userAddressRepository;



    public AuthService(UserManager<AppUser> userManager, AddressService addressService, SignInManager<AppUser> signInManager, RoleManager<IdentityRole> roleManager, UserAddressRepository userAddressRepository)
    {
        _userManager = userManager;
        _addressService = addressService;
        _signInManager = signInManager;
        _roleManager = roleManager;
        _userAddressRepository = userAddressRepository;
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

            if (!await _userManager.Users.AnyAsync())
            {
                roleName = "Admin";
            }
            else if (!string.IsNullOrEmpty(model.SelectedRole))
            {
                roleName = model.SelectedRole;
            }

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
            return false;
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




    public async Task<(AppUser user, UserAddressEntity address)> GetUserWithIdAsync(string userId)
    {
        var user = await _userManager.Users.Include(u => u.Addresses).FirstOrDefaultAsync(u => u.Id == userId);

        if (user != null)
        {
            var address = await _addressService.GetAsync(a => a.Users.Any(ua => ua.UserId == userId));

            if (address != null)
            {
                return (user, new UserAddressEntity { UserId = userId, AddressId = address.Id });
            }
        }

        return (null, null);
    }





    public async Task<IEnumerable<(AppUser user, IEnumerable<string> roles, IEnumerable<UserAddressEntity> addresses)>> GetAllUsersAsync()
    {
        var users = await _userManager.Users
            .Include(u => u.Addresses)
            .ToListAsync();

        var roles = await _roleManager.Roles.ToListAsync();

        var result = new List<(AppUser user, IEnumerable<string> roles, IEnumerable<UserAddressEntity> addresses)>();

        foreach (var user in users)
        {
            var userRoles = await _userManager.GetRolesAsync(user);
            var userRoleNames = userRoles.Select(r => r.ToString());
            var userAddresses = user.Addresses;

            var userTuple = (user, userRoleNames, userAddresses);
            result.Add(userTuple);
        }

        return result;
    }




}



//public async Task<bool> RegisterUserAsync(UserRegisterViewModel model)
//{
//    try
//    {
//        AppUser appUser = model;
//        var roleName = "User";


//        if (!await _roleManager.Roles.AnyAsync())
//        {
//            await _roleManager.CreateAsync(new IdentityRole("Admin"));
//            await _roleManager.CreateAsync(new IdentityRole("User"));
//        }

//        roleName = "User";
//        if (!await _userManager.Users.AnyAsync())
//            roleName = "Admin";

//        var result = await _userManager.CreateAsync(appUser, model.Password);
//        if (result.Succeeded)
//        {
//            await _userManager.AddToRoleAsync(appUser, roleName);

//            var addressEntity = await _addressService.GetOrCreateAsync(model);
//            if (addressEntity != null)
//            {
//                await _addressService.AddAddressAsync(appUser, addressEntity);
//                return true;
//            }
//        }
//        return true;
//    }
//    catch { return false; }
//}