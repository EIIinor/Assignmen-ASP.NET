using Assignmen_ASP.NET.Models;

namespace Assignmen_ASP.NET.ViewModels;

public class GridCollectionViewModel
{
    public string Title { get; set; } = "";
    public IEnumerable<string> Categories { get; set; } = null!;
    public IEnumerable<GridCollectionItemModel> GridItems { get; set; } = null!;
    public bool LoadMore { get; set; } = false;
}
