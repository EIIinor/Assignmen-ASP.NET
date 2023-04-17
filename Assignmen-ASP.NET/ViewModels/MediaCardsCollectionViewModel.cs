using Assignmen_ASP.NET.Models;

namespace Assignmen_ASP.NET.ViewModels;

public class MediaCardsCollectionViewModel
{
    public string Title { get; set; } = "";
    public IEnumerable<MediaCardItemModel> MediaCards { get; set; } = null!;
}
