using Assignmen_ASP.NET.Contexts;
using Assignmen_ASP.NET.Models.Entities;

namespace Assignmen_ASP.NET.Helpers.Repositories;

public class AddressRepository : Repository<IdentityContext, AddressEntity>
{
    public AddressRepository(IdentityContext context) : base(context)
    {
    }
}



//public class AddressRepository : Repository<AddressEntity>
//{
//    public AddressRepository(IdentityContext context) : base(context)
//    {
//    }
//}
