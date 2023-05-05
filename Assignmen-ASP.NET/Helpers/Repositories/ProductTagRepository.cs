using Assignmen_ASP.NET.Contexts;
using Assignmen_ASP.NET.Models.Entities;

namespace Assignmen_ASP.NET.Helpers.Repositories;


public class ProductTagRepository : Repository<DataContext, ProductTagEntity>
{
    public ProductTagRepository(DataContext context) : base(context)
    {
    }
}



//public class ProductTagRepository : Repository<ProductTagEntity>
//{
//    public ProductTagRepository(IdentityContext context) : base(context)
//    {
//    }
//}
