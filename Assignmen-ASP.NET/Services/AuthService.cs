using Assignmen_ASP.NET.Helpers.Repositories;
using Assignmen_ASP.NET.Models;
using Assignmen_ASP.NET.Models.Entities;
using Assignmen_ASP.NET.Models.Identity;
using Assignmen_ASP.NET.ViewModels;
using Microsoft.AspNetCore.Hosting;
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
    private readonly IWebHostEnvironment _webHostEnvironment;
    private readonly AppUserRepository _appUserRepository;



    public AuthService(UserManager<AppUser> userManager, AddressService addressService, SignInManager<AppUser> signInManager, RoleManager<IdentityRole> roleManager, UserAddressRepository userAddressRepository, IWebHostEnvironment webHostEnvironment, AppUserRepository appUserRepository)
    {
        _userManager = userManager;
        _addressService = addressService;
        _signInManager = signInManager;
        _roleManager = roleManager;
        _userAddressRepository = userAddressRepository;
        _webHostEnvironment = webHostEnvironment;
        _appUserRepository = appUserRepository;
    }



    public async Task<bool> RegisterUserAsync(UserRegisterViewModel model, IFormFile ImageFile)
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

                if (ImageFile != null)
                {
                    appUser.ImageUrl = $"{Guid.NewGuid()}_{ImageFile.FileName}";
                    await SaveProfilePictureAsync(ImageFile, appUser.ImageUrl);
                    await _userManager.UpdateAsync(appUser);
                }

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



    private async Task SaveProfilePictureAsync(IFormFile ImageFile, string imageUrl)
    {
        string imagePath = Path.Combine(_webHostEnvironment.WebRootPath, "images", "profiles", imageUrl);

        using (var stream = new FileStream(imagePath, FileMode.Create))
        {
            await ImageFile.CopyToAsync(stream);
        }
    }



    public string GetUserImageUrl(string userId)
    {
        var user = _userManager.FindByIdAsync(userId).Result;

        if (user != null)
        {
            return user.ImageUrl;
        }

        return null;
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

            return (user, new UserAddressEntity { UserId = userId, Address = address ?? new AddressEntity() });
        }

        return (null, null);
    }

    public async Task<UserAddressEntity> GetUserAddressAsync(string userId)
    {
        var addressEntity = await _addressService.GetAsync(a => a.Users.Any(ua => ua.UserId == userId));

        return new UserAddressEntity
        {
            UserId = userId,
            Address = addressEntity
        };
    }




    public async Task<IEnumerable<(AppUser user, IEnumerable<string> roles, IEnumerable<UserAddressEntity> addresses)>> GetAllUsersAsync()
    {
        var users = await _userManager.Users.ToListAsync();
        var roles = await _roleManager.Roles.ToListAsync();

        var result = new List<(AppUser user, IEnumerable<string> roles, IEnumerable<UserAddressEntity> addresses)>();

        foreach (var user in users)
        {
            var userRoles = await _userManager.GetRolesAsync(user);
            var userRoleNames = userRoles.Select(r => r.ToString());
            var userAddresses = await _userAddressRepository.GetAllAsync(ua => ua.UserId == user.Id, ua => ua.Address);

            var userTuple = (user, userRoleNames, userAddresses);
            result.Add(userTuple);
        }

        return result;
    }



    public async Task UpdateUserWithAddressAndRoleAsync(AppUser user, AddressEntity address, string role)
    {
        // Uppdatera användaruppgifter
        var updateUserResult = await _userManager.UpdateAsync(user);
        if (!updateUserResult.Succeeded)
        {
            // Hantera fel vid uppdatering av användaren
            throw new Exception("Failed to update user.");
        }

        // Uppdatera adressuppgifter
        var userAddress = await GetUserAddressAsync(user.Id);
        if (userAddress != null)
        {
            userAddress.Address.StreetName = address.StreetName;
            userAddress.Address.PostalCode = address.PostalCode;
            userAddress.Address.City = address.City;

            var updateAddressResult = await _addressService.UpdateUserAddressAsync(userAddress);
            if (!updateAddressResult)
            {
                // Hantera fel vid uppdatering av adressen
                throw new Exception("Failed to update address.");
            }
        }

        // Uppdatera rollen
        var userRoles = await _userManager.GetRolesAsync(user);
        var removeRoleResult = await _userManager.RemoveFromRolesAsync(user, userRoles);
        if (!removeRoleResult.Succeeded)
        {
            // Hantera fel vid borttagning av befintlig roll
            throw new Exception("Failed to remove user role.");
        }

        var addRoleResult = await _userManager.AddToRoleAsync(user, role);
        if (!addRoleResult.Succeeded)
        {
            // Hantera fel vid tillägg av ny roll
            throw new Exception("Failed to add user role.");
        }
    }
}



//public async Task<IEnumerable<(AppUser user, IEnumerable<string> roles, IEnumerable<UserAddressEntity> addresses)>> GetAllUsersAsync()
//{
//    var users = await _userManager.Users
//        .Include(u => u.Addresses)
//        .ToListAsync();

//    var roles = await _roleManager.Roles.ToListAsync();

//    var result = new List<(AppUser user, IEnumerable<string> roles, IEnumerable<UserAddressEntity> addresses)>();

//    foreach (var user in users)
//    {

//        var userRoles = await _userManager.GetRolesAsync(user);
//        var userRoleNames = userRoles.Select(r => r.ToString());
//        var userAddresses = user.Addresses;

//        var userTuple = (user, userRoleNames, userAddresses);
//        result.Add(userTuple);
//    }

//    return result;
//}



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