using Assignmen_ASP.NET.Migrations;
using Assignmen_ASP.NET.Models.Entities;
using Assignmen_ASP.NET.Models.Identity;
using System.ComponentModel.DataAnnotations;


namespace Assignmen_ASP.NET.ViewModels
{
    public class UserRegisterViewModel
    {
        //public AppUser User { get; set; }
        //public AddressEntity Address { get; set; }


        [Required(ErrorMessage = "Firstname is required")]
        [Display(Name = "First Name*")]
        [RegularExpression(@"^[a-öA-Ö]+(?:[é'-][a-öA-Ö]+)*$", ErrorMessage = "You must entar e valid firstname")]
        public string FirstName { get; set; } = null!;



        [Required(ErrorMessage = "Lastname is required")]
        [Display(Name = "Last Name*")]
        [RegularExpression(@"^[a-öA-Ö]+(?:[é'-][a-öA-Ö]+)*$", ErrorMessage = "You must entar e valid lastname")]
        public string LastName { get; set; } = null!;


        [Required(ErrorMessage = "Streetname is required*")]
        [Display(Name = "Streetname")]
        public string StreetName { get; set; } = null!;


        [Required(ErrorMessage = "Postalcode is required")]
        [Display(Name = "Postal Code*")]
        public string PostalCode { get; set; } = null!;


        [Required(ErrorMessage = "City is required")]
        [Display(Name = "City*")]
        public string City { get; set; } = null!;


        [Display(Name = "Mobile")]
        public string? PhoneNumber { get; set; }


        [Display(Name = "Company")]
        public string? CompanyName { get; set; }


        [Required(ErrorMessage = "E-mail is required")]
        [Display(Name = "E-mail*")]
        [DataType(DataType.EmailAddress)]
        [RegularExpression(@"[-A-Za-z0-9!#$%&'*+/=?^_`{|}~]+(?:\.[-A-Za-z0-9!#$%&'*+/=?^_`{|}~]+)*@(?:[A-Za-z0-9](?:[-A-Za-z0-9]*[A-Za-z0-9])?\.)+[A-Za-z0-9](?:[-A-Za-z0-9]*[A-Za-z0-9])?", ErrorMessage = "Enter valid email")]
        public string Email { get; set; } = null!;

     

        [Required(ErrorMessage = "Password is required")]
        [Display(Name = "Password*")]
        [DataType(DataType.Password)]
        [RegularExpression(@"^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$ %^&*-]).{8,}$", ErrorMessage = "Enter valid password")]
        public string Password { get; set; } = null!;



        [Required(ErrorMessage = "Confirming password is required")]
        [Compare(nameof(Password), ErrorMessage = "Password is not matching")]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm password*")]
        public string ConfirmPassword { get; set; } = null!;



        [Display(Name = "Upload profile image")]
        [DataType(DataType.Upload)]
        public IFormFile? ImageFile { get; set; }


        [Required(ErrorMessage = "You need to accept")]
        [Display(Name = "I have read and accept the terms and agreements")]
        public bool TermsAndAgreement { get; set; } = false;


        //public string? SelectedRole { get; set; } // new property for selected role



        public static implicit operator AppUser(UserRegisterViewModel model)
        {
            var appUser = new AppUser
            {
                UserName = model.Email,
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email,
                PhoneNumber = model.PhoneNumber,
                CompanyName = model.CompanyName,
            };

            if (model.ImageFile != null)
            {
                appUser.ImageUrl = $"{Guid.NewGuid()}_{model.ImageFile?.FileName}";
            }

            return appUser;
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
    }
}


