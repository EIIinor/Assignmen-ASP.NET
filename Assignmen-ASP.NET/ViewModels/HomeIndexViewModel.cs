using Assignmen_ASP.NET.Models;

namespace Assignmen_ASP.NET.ViewModels;

public class HomeIndexViewModel
{
    public string Title { get; set; } = "Home";
    public ShowcaseModel Showcase { get; set; } = null!;
    public GridCollectionViewModel BestCollection { get; set; } = null!;
    public GridCollectionViewModel PopularCollection { get; set; } = null!;
    public GridCollectionViewModel NewCollection { get; set; } = null!;
    public GridCollectionViewModel FeaturedCollection { get; set; } = null!;
    public UpToSellViewModel UpToSell { get; set; } = null!;

    public TopSellingViewModel TopSelling { get; set; } = null!;

    public MediaCardsCollectionViewModel TopSocialMedia { get; set; } = null!;
}
