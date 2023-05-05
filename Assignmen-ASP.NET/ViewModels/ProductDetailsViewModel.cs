using Assignmen_ASP.NET.Models;

namespace Assignmen_ASP.NET.ViewModels;

public class ProductDetailsViewModel
{
    public IEnumerable<ProductModel> Products { get; set; } = new List<ProductModel>();
}
