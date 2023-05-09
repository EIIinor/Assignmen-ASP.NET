using Assignmen_ASP.NET.Contexts;
using Assignmen_ASP.NET.Models.Entities;

namespace Assignmen_ASP.NET.Helpers.Repositories;


public class UserAddressRepository : Repository<IdentityContext, UserAddressEntity>
{
    public UserAddressRepository(IdentityContext context) : base(context)
    {
    }
}
