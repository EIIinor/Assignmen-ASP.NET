using Assignmen_ASP.NET.Contexts;
using Assignmen_ASP.NET.Models.Entities;
using Assignmen_ASP.NET.ViewModels;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Assignmen_ASP.NET.Services;

public class UserService
{

    //private readonly DataContext _context;

    //public UserService(DataContext context)
    //{
    //    _context = context;
    //}

    //public async Task<bool> UserExist(Expression<Func<UserEntity, bool>> predicate)
    //{
    //    //if (await _context.Users.AnyAsync(predicate))
    //    //    return true;

    //    return false;
    //}

    //public async Task<UserEntity> GetAsync(Expression<Func<UserEntity, bool>> predicate)
    //{
    //    //var userEntity = await _context.Users.FirstOrDefaultAsync(predicate);
    //    //return userEntity!;

    //}

    //public async Task<bool> RegisterAsync(UserRegisterViewModel userRegisterViewModel)
    //{
    //    try
    //    {
    //        UserEntity userEntity = userRegisterViewModel;
    //        ProfileEntity profileEntity = userRegisterViewModel;


    //        _context.Users.Add(userEntity);
    //        await _context.SaveChangesAsync();

    //        profileEntity.UserId = userEntity.Id;
    //        _context.Profiles.Add(profileEntity);
    //        await _context.SaveChangesAsync();

    //        return true;
    //    }
    //    catch
    //    {
    //        return false;
    //    }
    //}

    //public async Task<bool> LoginAsync(UserLoginViewModel userLoginViewModel)
    //{
    //    var userEntity = await GetAsync(x => x.Email == userLoginViewModel.Email);
    //    if (userEntity != null)
    //        return userEntity.VerifySecurePassword(userLoginViewModel.Password);
    //    return false;
    //}
}
