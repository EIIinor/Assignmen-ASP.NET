using Assignmen_ASP.NET.Models.Entities;
using System.ComponentModel.DataAnnotations;

namespace Assignmen_ASP.NET.ViewModels;

public class ProductRegisterViewModel
{
    [Required(ErrorMessage = "Product name is required")]
    [Display(Name = "Product name *")]
    public string Name { get; set; } = null!;

    [Display(Name = "Product description (optional)")]
    public string? Description { get; set; }

    [Required(ErrorMessage = "Prodict price is required")]
    [Display(Name = "Product price *")]
    [DataType(DataType.Currency)]
    public decimal Price { get; set; }

    [Display(Name = "Product imageurl (optional)")]
    public string? ImageUrl { get; set; }


    public static implicit operator ProductEntity(ProductRegisterViewModel productRegisterViewModel)
    {
        return new ProductEntity
        {
            Name = productRegisterViewModel.Name,
            Description = productRegisterViewModel.Description,
            Price = productRegisterViewModel.Price,
            ImageUrl = productRegisterViewModel.ImageUrl,
        };
    }
}
