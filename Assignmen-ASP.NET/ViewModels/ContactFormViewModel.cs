using Assignmen_ASP.NET.Models.Entities;
using System.ComponentModel.DataAnnotations;

namespace Assignmen_ASP.NET.ViewModels;

public class ContactFormViewModel
{

    [Required(ErrorMessage = "Firstname is required")]
    [Display(Name = "Your Name*")]
    public string Name { get; set; } = null!;


    [Required(ErrorMessage = "E-mail is required")]
    [Display(Name = "Your E-mail*")]
    [DataType(DataType.EmailAddress)]
    [RegularExpression(@"[-A-Za-z0-9!#$%&'*+/=?^_`{|}~]+(?:\.[-A-Za-z0-9!#$%&'*+/=?^_`{|}~]+)*@(?:[A-Za-z0-9](?:[-A-Za-z0-9]*[A-Za-z0-9])?\.)+[A-Za-z0-9](?:[-A-Za-z0-9]*[A-Za-z0-9])?", ErrorMessage = "Enter valid email")]
    public string Email { get; set; } = null!;


    [Display(Name = "Phone Number")]
    public string? PhoneNumber { get; set; }


    [Display(Name = "Company (optional)")]
    public string? Company { get; set; }



    [Required(ErrorMessage = "Comment is required")]
    [Display(Name = "Leave a comment*")]
    public string? Text { get; set; }



    [Display(Name = "Save my name, email, and website in this browser for the next time I comment")]
    public bool SaveMe { get; set; } = false;



    public static implicit operator ContactFormEntity(ContactFormViewModel contactFormViewModel)
    {
        return new ContactFormEntity
        {
            Name = contactFormViewModel.Name,
            Email = contactFormViewModel.Email,
            PhoneNumber = contactFormViewModel.PhoneNumber,
            Company = contactFormViewModel.Company,
            Text = contactFormViewModel.Text,
            SaveMe = contactFormViewModel.SaveMe,
        };
    }
}
