using Assignmen_ASP.NET.Contexts;
using Assignmen_ASP.NET.Helpers.Repositories;
using Assignmen_ASP.NET.Models;
using Assignmen_ASP.NET.Models.Entities;
using Assignmen_ASP.NET.ViewModels;

namespace Assignmen_ASP.NET.Services;

public class ContactFormService
{
    private readonly DataContext _context;
    private readonly ContactFormRepository _contactFormRepo;

    public ContactFormService(DataContext context, ContactFormRepository contactFormRepo)
    {
        _context = context;
        _contactFormRepo = contactFormRepo;
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


    public async Task<IEnumerable<ContactFormEntity>> GetAllASync()
    {
        var items = await _contactFormRepo.GetAllAsync();
        var list = new List<ContactFormEntity>();
        foreach (var item in items)
            list.Add(item);
        return list;
    }


}
