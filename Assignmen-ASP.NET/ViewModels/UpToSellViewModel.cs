using Assignmen_ASP.NET.Models;

namespace Assignmen_ASP.NET.ViewModels;

public class UpToSellViewModel
{
    public string Title { get; set; } = null!;
    public string? TitleRed { get; set; }
    public string? Ingress { get; set; }
    public string? Text { get; set; }
    public string? LinkContent { get; set; }
    public string? LinkUrl { get; set; }

    public IEnumerable<GridCollectionItemModel> GridItems { get; set; } = null!;
}
