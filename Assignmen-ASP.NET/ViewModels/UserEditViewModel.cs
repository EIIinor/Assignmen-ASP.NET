using Assignmen_ASP.NET.Models.Entities;
using Assignmen_ASP.NET.Models.Identity;
using System.ComponentModel.DataAnnotations;

namespace Assignmen_ASP.NET.ViewModels;

public class UserEditViewModel {

    public string Id { get; set; }



    [Display(Name = "First Name*")]
    public string? FirstName { get; set; } = null!;



    [Display(Name = "Last Name*")]
    [RegularExpression(@"^[a-öA-Ö]+(?:[é'-][a-öA-Ö]+)*$", ErrorMessage = "You must entar e valid lastname")]
    public string? LastName { get; set; } = null!;



    [Display(Name = "Streetname")]
    public string? StreetName { get; set; } = null!;


    [Display(Name = "Postal Code")]
    public string? PostalCode { get; set; } = null!;


    [Display(Name = "City*")]
    public string? City { get; set; } = null!;


    [Display(Name = "Mobile")]
    public string? PhoneNumber { get; set; }


    [Display(Name = "Company")]
    public string? CompanyName { get; set; }



    [Display(Name = "E-mail")]
    [DataType(DataType.EmailAddress)]
    [RegularExpression(@"[-A-Za-z0-9!#$%&'*+/=?^_`{|}~]+(?:\.[-A-Za-z0-9!#$%&'*+/=?^_`{|}~]+)*@(?:[A-Za-z0-9](?:[-A-Za-z0-9]*[A-Za-z0-9])?\.)+[A-Za-z0-9](?:[-A-Za-z0-9]*[A-Za-z0-9])?", ErrorMessage = "Enter valid email")]
    public string? Email { get; set; } = null!;




    [Display(Name = "Password")]
    [DataType(DataType.Password)]
    [RegularExpression(@"^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$ %^&*-]).{8,}$", ErrorMessage = "Enter valid password")]
    public string? Password { get; set; } = null!;




    [Compare(nameof(Password), ErrorMessage = "Password is not matching")]
    [DataType(DataType.Password)]
    [Display(Name = "Confirm password")]
    public string? ConfirmPassword { get; set; } = null!;



    [Display(Name = "Upload profile image")]
    [DataType(DataType.Upload)]
    public IFormFile? ImageFile { get; set; }



    public string? SelectedRole { get; set; } // new property for selected role



    public static implicit operator AppUser(UserEditViewModel model)
    {
    return new AppUser
    {
        UserName = model.Email,
        FirstName = model.FirstName,
        LastName = model.LastName,
        Email = model.Email,
        PhoneNumber = model.PhoneNumber,
        CompanyName = model.CompanyName,
    };
    }

    public static implicit operator AddressEntity(UserEditViewModel model)
    {
    return new AddressEntity
    {
        StreetName = model.StreetName,
        PostalCode = model.PostalCode,
        City = model.City,
    };

    }
}
