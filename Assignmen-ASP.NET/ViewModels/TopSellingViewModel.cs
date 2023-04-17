using Assignmen_ASP.NET.Models;

namespace Assignmen_ASP.NET.ViewModels
{
    public class TopSellingViewModel
    {
        public string Title { get; set; } = null!;
        public string LinkUrl { get; set; } = null!;
        public IEnumerable<GridCollectionItemModel> GridItems { get; set; } = null!;
    }
}
