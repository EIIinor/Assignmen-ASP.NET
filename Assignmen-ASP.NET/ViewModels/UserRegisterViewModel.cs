using Assignmen_ASP.NET.Models.Entities;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Assignmen_ASP.NET.ViewModels
{
    public class UserRegisterViewModel
    {
        [Required(ErrorMessage = "Firstname is required")]
        [Display(Name = "FirstName")]
        [RegularExpression(@"^[a-öA-Ö]+(?:[é'-][a-öA-Ö]+)*$", ErrorMessage = "Du måste ange ett giltigt förnamn")]
        public string FirstName { get; set; } = null!;


        [Required(ErrorMessage = "Lastname is required")]
        [Display(Name = "LastName")]
        [RegularExpression(@"^[a-öA-Ö]+(?:[é'-][a-öA-Ö]+)*$", ErrorMessage = "Du måste ange ett giltigt efternamn")]
        public string LastName { get; set; } = null!;


        [Required(ErrorMessage = "E-mail is required")]
        [Display(Name = "E-mail Address")]
        [DataType(DataType.EmailAddress)]
        [RegularExpression(@"[-A-Za-z0-9!#$%&'*+/=?^_`{|}~]+(?:\.[-A-Za-z0-9!#$%&'*+/=?^_`{|}~]+)*@(?:[A-Za-z0-9](?:[-A-Za-z0-9]*[A-Za-z0-9])?\.)+[A-Za-z0-9](?:[-A-Za-z0-9]*[A-Za-z0-9])?", ErrorMessage = "Du måste ange en giltig e-postadress")]
        public string Email { get; set; } = null!;

     
        [Display(Name = "Phonenumber")]
        public string? PhoneNumber { get; set; }


        [Required(ErrorMessage = "Password is required")]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        [RegularExpression(@"^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$ %^&*-]).{8,}$", ErrorMessage = "Du måste ange ett giltigt lösenord")]
        public string Password { get; set; } = null!;


        [Required(ErrorMessage = "Confirming password is required")]
        [Compare(nameof(Password), ErrorMessage = "Password is not matching")]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        public string ConfirmPassword { get; set; } = null!;



        [Display(Name = "Streetname")]
        public string? StreetName { get; set; }


        [Display(Name = "Postal Code")]
        public string? PostalCode { get; set; }


        [Display(Name = "City")]
        public string? City { get; set; }



        public static implicit operator IdentityUser(UserRegisterViewModel model)
        {
            return new IdentityUser
            {
                UserName = model.Email,
                Email = model.Email,
                PhoneNumber = model.PhoneNumber,
            };
        }
        
        public static implicit operator UserProfileEntity(UserRegisterViewModel model)
        {
            return new UserProfileEntity
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                StreetName = model.StreetName,
                PostalCode = model.PostalCode,
                City = model.City,
            };           
        }



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
