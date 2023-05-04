using Assignmen_ASP.NET.Contexts;
using Assignmen_ASP.NET.Migrations.Data;

namespace Assignmen_ASP.NET.Helpers.Repositories;

public class CategoryRepository : Repository<CategoryEntity>
{
    public CategoryRepository(IdentityContext context) : base(context)
    {
    }
}
