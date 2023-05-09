using Assignmen_ASP.NET.Contexts;
using Assignmen_ASP.NET.Models.Entities;

namespace Assignmen_ASP.NET.Helpers.Repositories;

public class ProductRepository : Repository<DataContext, ProductEntity>
{
    public ProductRepository(DataContext context) : base(context)
    {
    }
}
