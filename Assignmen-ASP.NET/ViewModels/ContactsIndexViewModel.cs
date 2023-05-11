using Assignmen_ASP.NET.Models;
using Assignmen_ASP.NET.Models.Entities;
using Assignmen_ASP.NET.Services;

namespace Assignmen_ASP.NET.ViewModels;

public class ContactsIndexViewModel
{
    public string Title { get; set; } = "Contact";
    public ContactFormViewModel ContactForm { get; set; } = null!;
    public IEnumerable<ContactFormEntity> Comments { get; set; } = new List<ContactFormEntity>();

    public ContactFormService ContactFormService { get; set; } = null!;
}



//public BreadcrumbModel Breadcrumb { get; set; } = null!;
//public MapModel Map { get; set; } = null!;