using Assignmen_ASP.NET.Models.Entities;
using Assignmen_ASP.NET.Models.Identity;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Assignmen_ASP.NET.ViewModels
{
    public class UserRegisterViewModel
    {


        [Required(ErrorMessage = "Firstname is required")]
        [Display(Name = "First Name")]
        [RegularExpression(@"^[a-öA-Ö]+(?:[é'-][a-öA-Ö]+)*$", ErrorMessage = "You must entar e valid firstname")]
        public string FirstName { get; set; } = null!;



        [Required(ErrorMessage = "Lastname is required")]
        [Display(Name = "Last Name")]
        [RegularExpression(@"^[a-öA-Ö]+(?:[é'-][a-öA-Ö]+)*$", ErrorMessage = "You must entar e valid lastname")]
        public string LastName { get; set; } = null!;


        [Required(ErrorMessage = "Streetname is required")]
        [Display(Name = "Streetname")]
        public string StreetName { get; set; } = null!;


        [Required(ErrorMessage = "Postalcode is required")]
        [Display(Name = "Postal Code")]
        public string PostalCode { get; set; } = null!;


        [Required(ErrorMessage = "City is required")]
        [Display(Name = "City")]
        public string City { get; set; } = null!;


        [Display(Name = "Mobile")]
        public string? PhoneNumber { get; set; }


        [Display(Name = "Company")]
        public string? CompanyName { get; set; }


        [Required(ErrorMessage = "E-mail is required")]
        [Display(Name = "E-mail")]
        [DataType(DataType.EmailAddress)]
        [RegularExpression(@"[-A-Za-z0-9!#$%&'*+/=?^_`{|}~]+(?:\.[-A-Za-z0-9!#$%&'*+/=?^_`{|}~]+)*@(?:[A-Za-z0-9](?:[-A-Za-z0-9]*[A-Za-z0-9])?\.)+[A-Za-z0-9](?:[-A-Za-z0-9]*[A-Za-z0-9])?", ErrorMessage = "Enter valid email")]
        public string Email { get; set; } = null!;

     

        [Required(ErrorMessage = "Password is required")]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        [RegularExpression(@"^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$ %^&*-]).{8,}$", ErrorMessage = "Enter valid password")]
        public string Password { get; set; } = null!;



        [Required(ErrorMessage = "Confirming password is required")]
        [Compare(nameof(Password), ErrorMessage = "Password is not matching")]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        public string ConfirmPassword { get; set; } = null!;



        [Display(Name = "Upload profile image")]
        [DataType(DataType.Upload)]
        public IFormFile? ImageFile { get; set; }


        [Required(ErrorMessage = "You need to accept")]
        [Display(Name = "I have read and accept the terms and agreements")]
        public bool TermsAndAgreement { get; set; } = false;






        public static implicit operator AppUser(UserRegisterViewModel model)
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

        public static implicit operator AddressEntity(UserRegisterViewModel model)
        {
            return new AddressEntity
            {
                StreetName = model.StreetName,
                PostalCode = model.PostalCode,
                City = model.City,
            };

        }



        //public static implicit operator IdentityUser(UserRegisterViewModel model)
        //{
        //    return new IdentityUser
        //    {
        //        UserName = model.Email,
        //        Email = model.Email,
        //        PhoneNumber = model.PhoneNumber,
        //    };
        //}



        //public static implicit operator UserProfileEntity(UserRegisterViewModel model)
        //{
        //    return new UserProfileEntity
        //    {
        //        FirstName = model.FirstName,
        //        LastName = model.LastName,
        //        StreetName = model.StreetName,
        //        PostalCode = model.PostalCode,
        //        City = model.City,
        //    };           
        //}


        //public static implicit operator UserEntity(UserRegisterViewModel userRegisterviewModel)
        //{
        //    var userEntity = new UserEntity { Email = userRegisterviewModel.Email };
        //    userEntity.GenerateSecurePassword(userRegisterviewModel.Password);
        //    return userEntity;
        //}

        //public static implicit operator ProfileEntity(UserRegisterViewModel userRegisterviewModel)
        //{
        //    return new ProfileEntity
        //    {
        //        FirstName = userRegisterviewModel.FirstName,
        //        LastName = userRegisterviewModel.LastName,
        //        StreetName = userRegisterviewModel.StreetName,
        //        PostalCode = userRegisterviewModel.PostalCode,
        //        City = userRegisterviewModel.City,
        //    };
        //}
    }
}
