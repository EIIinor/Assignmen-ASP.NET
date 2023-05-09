using Assignmen_ASP.NET.Models;

namespace Assignmen_ASP.NET.ViewModels;

public class ProductsIndexViewModel
{
    public string Title { get; set; } = "Products";
    public IEnumerable<ProductModel> Products { get; set; } = new List<ProductModel>();
}






//public GridCollectionViewModel All { get; set; } = null!;

//public IEnumerable<GridCollectionItemModel> GridItems { get; set; } = null!;