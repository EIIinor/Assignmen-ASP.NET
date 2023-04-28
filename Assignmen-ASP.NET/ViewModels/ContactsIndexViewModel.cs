using Assignmen_ASP.NET.Models;

namespace Assignmen_ASP.NET.ViewModels;

public class ContactsIndexViewModel
{
    public string Title { get; set; } = "Contact";
    //public BreadcrumbModel Breadcrumb { get; set; } = null!;
    //public MapModel Map { get; set; } = null!;
    public ContactFormViewModel ContactForm { get; set; } = null!;
}
