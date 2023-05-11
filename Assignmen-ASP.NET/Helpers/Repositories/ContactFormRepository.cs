using Assignmen_ASP.NET.Contexts;
using Assignmen_ASP.NET.Models.Entities;

namespace Assignmen_ASP.NET.Helpers.Repositories;


public class ContactFormRepository : Repository<DataContext, ContactFormEntity>
{
    public ContactFormRepository(DataContext context) : base(context)
    {
    }
}
