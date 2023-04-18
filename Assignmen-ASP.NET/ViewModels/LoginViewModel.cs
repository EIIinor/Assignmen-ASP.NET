using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Assignmen_ASP.NET.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Du måste ange en e-postadress")]
        [Display(Name = "E-postadress")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; } = null!;

        [Required(ErrorMessage = "Du måste ange ett lösenord")]
        [Display(Name = "Lösenord")]
        [DataType(DataType.Password)]
        public string Password { get; set; } = null!;
    }
}
