using Assignmen_ASP.NET.Contexts;
using Assignmen_ASP.NET.Models.Identity;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Assignmen_ASP.NET.Helpers.Repositories;

public class AppUserRepository : Repository<IdentityContext, AppUser>
{
    public AppUserRepository(IdentityContext context) : base(context)
    {
    }


}
