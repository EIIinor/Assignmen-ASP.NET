using Assignmen_ASP.NET.Contexts;
using Assignmen_ASP.NET.Models.Entities;

namespace Assignmen_ASP.NET.Helpers.Repositories;


public class CategoryRepository : Repository<DataContext, CategoryEntity>
{
    public CategoryRepository(DataContext context) : base(context)
    {
    }
}




//public class CategoryRepository : Repository<CategoryEntity>
//{
//    public CategoryRepository(IdentityContext context) : base(context)
//    {
//    }
//}
