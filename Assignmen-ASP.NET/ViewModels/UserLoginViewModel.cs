using System.ComponentModel.DataAnnotations;

namespace Assignmen_ASP.NET.ViewModels
{
    public class UserLoginViewModel
    {
        [Required(ErrorMessage = "Email is required")]
        [Display(Name = "E-mail*")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; } = null!;


        [Required(ErrorMessage = "Password is required")]
        [Display(Name = "Password*")]
        [DataType(DataType.Password)]
        public string Password { get; set; } = null!;


        [Display(Name = "Keep me logged in")]
        public bool RememberMe { get; set; } = false;
    }
}
