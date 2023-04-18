using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Assignmen_ASP.NET.ViewModels
{
    public class UserRegisterViewModel
    {
        [Required(ErrorMessage = "First name is required")]
        [Display(Name = "First Name")]
        [RegularExpression(@"^[a-öA-Ö]+(?:[é'-][a-öA-Ö]+)*$", ErrorMessage = "Du måste ange ett giltigt förnamn")]
        public string FirstName { get; set; } = null!;


        [Required(ErrorMessage = "First name is required")]
        [Display(Name = "Last Name")]
        [RegularExpression(@"^[a-öA-Ö]+(?:[é'-][a-öA-Ö]+)*$", ErrorMessage = "Du måste ange ett giltigt efternamn")]
        public string LastName { get; set; } = null!;


        [Required(ErrorMessage = "E-mail is required")]
        [Display(Name = "E-mail Address")]
        [DataType(DataType.EmailAddress)]
        [RegularExpression(@"[-A-Za-z0-9!#$%&'*+/=?^_`{|}~]+(?:\.[-A-Za-z0-9!#$%&'*+/=?^_`{|}~]+)*@(?:[A-Za-z0-9](?:[-A-Za-z0-9]*[A-Za-z0-9])?\.)+[A-Za-z0-9](?:[-A-Za-z0-9]*[A-Za-z0-9])?", ErrorMessage = "Du måste ange en giltig e-postadress")]
        public string Email { get; set; } = null!;


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


        //public static implicit operator CustomIdentityUser(RegisterUsersViewModel viewModel)
        //{
        //    return new CustomIdentityUser
        //    {
        //        UserName = viewModel.Email,
        //        Firstname = viewModel.FirstName,
        //        Lastname = viewModel.LastName,
        //        Email = viewModel.Email,
        //    };
        //}
    }
}
