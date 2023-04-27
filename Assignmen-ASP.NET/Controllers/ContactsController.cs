using Assignmen_ASP.NET.Models;
using Assignmen_ASP.NET.Services;
using Assignmen_ASP.NET.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Assignmen_ASP.NET.Controllers;

public class ContactsController : Controller
{


    private readonly ContactFormService _contactFormService;

    public ContactsController(ContactFormService contactFormService)
    {
        _contactFormService = contactFormService;
    }




    public IActionResult Index()
    {
        var viewModel = new ContactsIndexViewModel()
        {

            Breadcrumb = new BreadcrumbModel()
            {
                Title = "Map",
                ImgUrl = "./images/placeholders/1920x300.svg",
            },


            Map = new MapModel()
            {
                MapUrl = "https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d3323.846379992451!2d18.021943310261673!3d59.34492585222009!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x465f9d9d263b022d%3A0x82fc0f30ed84f9ed!2sNackademin!5e0!3m2!1ssv!2sse!4v1679451477145!5m2!1ssv!2sse",
            },



        };

        return View(viewModel);
    }

    [HttpPost]
    public async Task <IActionResult> Index(ContactsIndexViewModel indexViewModel, ContactFormViewModel viewModel)
    {
        if(ModelState.IsValid)
        {
            if (await _contactFormService.CreateAsync(viewModel))
                return RedirectToAction(nameof(Index));

            ModelState.AddModelError("", "Something went wrong");
        }

        if (viewModel == null)
        {
            viewModel = new ContactFormViewModel();
        }

        return View(indexViewModel);
    }
}
