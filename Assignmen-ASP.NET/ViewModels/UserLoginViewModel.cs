using System.ComponentModel.DataAnnotations;

namespace Assignmen_ASP.NET.ViewModels
{
    public class UserLoginViewModel
    {
        [Required(ErrorMessage = "Email is required")]
        [Display(Name = "E-postadress")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; } = null!;

        [Required(ErrorMessage = "Password is required")]
        [Display(Name = "Lösenord")]
        [DataType(DataType.Password)]
        public string Password { get; set; } = null!;

        public bool RememberMe { get; set; }
    }
}
