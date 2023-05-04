using Assignmen_ASP.NET.Models.Entities;
using System.ComponentModel.DataAnnotations;

namespace Assignmen_ASP.NET.ViewModels;

public class ProductRegisterViewModel
{

    [Required(ErrorMessage = "Product ArticleNumber is required")]
    [Display(Name = "Product ArticleNumber *")]
    public string ArticleNumber { get; set; } = null!;


    [Required(ErrorMessage = "Product name is required")]
    [Display(Name = "Product name *")]
    public string Name { get; set; } = null!;


    [Display(Name = "Product description (optional)")]
    public string? Description { get; set; }


    [Required(ErrorMessage = "Product price is required")]
    [Display(Name = "Product price *")]
    [DataType(DataType.Currency)]
    public decimal Price { get; set; }


    [Display(Name = "Product Image (optional)")]
    [DataType(DataType.Upload)]
    public IFormFile? Image { get; set; }




    public static implicit operator ProductEntity(ProductRegisterViewModel viewModel)
    {
        var entity = new ProductEntity
        {
            ArticleNumber = viewModel.ArticleNumber,
            Name = viewModel.Name,
            Description = viewModel.Description,
            Price = viewModel.Price,
        };

        if (viewModel.Image != null)
            entity.ImageUrl = $"{Guid.NewGuid()}_{viewModel.Image?.FileName}";
        return entity;

    }
}