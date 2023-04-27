using Assignmen_ASP.NET.Contexts;
using Assignmen_ASP.NET.Models.Entities;
using Assignmen_ASP.NET.ViewModels;

namespace Assignmen_ASP.NET.Services;

public class ContactFormService
{
    private readonly DataContext _context;

    public ContactFormService(DataContext context)
    {
        _context = context;
    }

    public async Task<bool> CreateAsync(ContactFormViewModel contactFormViewModel)
    {
        try
        {
            ContactFormEntity contactFormEntity = contactFormViewModel;

            _context.Comments.Add(contactFormEntity);
            await _context.SaveChangesAsync();
            return true;
        }
        catch
        {
            return false;
        }
    }




}
