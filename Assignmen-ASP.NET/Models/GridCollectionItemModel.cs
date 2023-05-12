namespace Assignmen_ASP.NET.Models;

public class GridCollectionItemModel
{
    public string Id { get; set; } = null!;
    public string ImageUrl { get; set; } = null!;
    public string Title { get; set; } = null!;
    public decimal Price { get; set; }

    public List<string> Tags { get; set; } = new List<string>();
}
