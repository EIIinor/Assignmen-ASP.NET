using Assignmen_ASP.NET.Models;
using Assignmen_ASP.NET.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Assignmen_ASP.NET.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        var viewModel = new HomeIndexViewModel()
        {


            UpToSell = new UpToSellViewModel()
            {
                GridItems = new List<GridCollectionItemModel>
                {
                    new GridCollectionItemModel { Id = "9", Title = "Apple watch collection", Price = 30, ImageUrl = "images/placeholders/369x310.svg" },
                },

                Title = "50% OFF",
                TitleRed = "UP TO SELL",
                Ingress = "Get The Best Price",
                Text = "Get the best daily offer et accusam et justo duo dolores et ea rebum. Stet clita kasd gubergren no sea taki",
                LinkContent = "Discover More",
                LinkUrl = "/products",
            },





            TopSelling = new TopSellingViewModel()
            {
                Title = "Top selling products in this week",
                LinkUrl = "/products",
                GridItems = new List<GridCollectionItemModel>
                {
                    new GridCollectionItemModel { Id = "9", Title = "Apple watch collection", Price = 30, ImageUrl = "images/placeholders/270x295.svg" },
                    new GridCollectionItemModel { Id = "10", Title = "Apple watch collection", Price = 30, ImageUrl = "images/placeholders/270x295.svg" },
                    new GridCollectionItemModel { Id = "11", Title = "Apple watch collection", Price = 30, ImageUrl = "images/placeholders/270x295.svg" },
                    new GridCollectionItemModel { Id = "12", Title = "Apple watch collection", Price = 30, ImageUrl = "images/placeholders/270x295.svg" },
                    new GridCollectionItemModel { Id = "13", Title = "Apple watch collection", Price = 30, ImageUrl = "images/placeholders/270x295.svg" },
                    new GridCollectionItemModel { Id = "14", Title = "Apple watch collection", Price = 30, ImageUrl = "images/placeholders/270x295.svg" },
                    new GridCollectionItemModel { Id = "15", Title = "Apple watch collection", Price = 30, ImageUrl = "images/placeholders/270x295.svg" },
                }
            },




            TopSocialMedia = new MediaCardsCollectionViewModel
            {
                MediaCards = new List<MediaCardItemModel>
                {
                    new MediaCardItemModel { Title = "Table lamp 1562 LTG modal", Ingress = "Best dress for everyone oof spåjeg njiosaew asgaih fuwf niow  fi ödn aihf afh", Stamp = "POST BY : ADMIN  COMMENTS: 13", ImageUrl = "images/placeholders/369x310.svg", },
                    new MediaCardItemModel { Title = "Table lamp 1562 LTG modal", Ingress = "Best dress for everyone oof spåjeg njiosaew asgaih fuwf niow  fi ödn aihf afh", Stamp = "POST BY : ADMIN  COMMENTS: 13", ImageUrl = "images/placeholders/369x310.svg", },
                    new MediaCardItemModel { Title = "Table lamp 1562 LTG modal", Ingress = "Best dress for everyone oof spåjeg njiosaew asgaih fuwf niow  fi ödn aihf afh", Stamp = "POST BY : ADMIN  COMMENTS: 13", ImageUrl = "images/placeholders/369x310.svg", },
                }
            },


            Showcase = new ShowcaseModel
            {
                Ingress = "WELCOME TO BMERKETO SHOP",
                Title = "Exclusive Charir gold Collection",
                LinkContent = "SHOP NOW",
                LinkUrl = "/products",
                ImageUrl = "images/placeholders/625x647.svg",

            },

            BestCollection = new GridCollectionViewModel
            {
                Title = "Best Collection",
                Categories = new List<string> { "All", "Bag", "Dress", "Decoration", "Essentials", "Interior", "Laptops", "Mobile", "Beauty" },
                GridItems = new List<GridCollectionItemModel>
                {
                    new GridCollectionItemModel { Id = "1", Title = "Apple watch collection", Price = 30, ImageUrl = "images/placeholders/270x295.svg" },
                    new GridCollectionItemModel { Id = "2", Title = "Apple watch collection", Price = 30, ImageUrl = "images/placeholders/270x295.svg" },
                    new GridCollectionItemModel { Id = "3", Title = "Apple watch collection", Price = 30, ImageUrl = "images/placeholders/270x295.svg" },
                    new GridCollectionItemModel { Id = "4", Title = "Apple watch collection", Price = 30, ImageUrl = "images/placeholders/270x295.svg" },
                    new GridCollectionItemModel { Id = "5", Title = "Apple watch collection", Price = 30, ImageUrl = "images/placeholders/270x295.svg" },
                    new GridCollectionItemModel { Id = "6", Title = "Apple watch collection", Price = 30, ImageUrl = "images/placeholders/270x295.svg" },
                    new GridCollectionItemModel { Id = "7", Title = "Apple watch collection", Price = 30, ImageUrl = "images/placeholders/270x295.svg" },
                    new GridCollectionItemModel { Id = "8", Title = "Apple watch collection", Price = 30, ImageUrl = "images/placeholders/270x295.svg" },
                }
            },



        };
        return View(viewModel);
    }
}
