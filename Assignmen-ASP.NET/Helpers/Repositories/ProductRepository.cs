using Assignmen_ASP.NET.Contexts;
using Assignmen_ASP.NET.Models.Entities;

namespace Assignmen_ASP.NET.Helpers.Repositories;

public class ProductRepository : Repository<DataContext, ProductEntity>
{
    public ProductRepository(DataContext context) : base(context)
    {
    }
}



//public class ProductRepository : Repository<ProductEntity>
//{
//    public ProductRepository(IdentityContext context) : base(context)
//    {
//    }
//}
