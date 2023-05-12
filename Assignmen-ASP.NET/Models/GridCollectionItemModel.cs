using Assignmen_ASP.NET.Models.Entities;

namespace Assignmen_ASP.NET.Models;

public class GridCollectionItemModel
{
    public string ArticleNumber { get; set; } = null!;
    public string ImageUrl { get; set; } = null!;
    public string Title { get; set; } = null!;
    public decimal Price { get; set; }

    public List<TagEntity> Tags { get; set; } = new List<TagEntity>();
}
