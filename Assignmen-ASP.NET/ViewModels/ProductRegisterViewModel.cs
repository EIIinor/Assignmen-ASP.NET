using Assignmen_ASP.NET.Models.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace Assignmen_ASP.NET.ViewModels;

public class ProductRegisterViewModel
{
    public ProductRegisterViewModel()
    {
    }


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




    [Display(Name = "New")]
    public bool New { get; set; }

    [Display(Name = "Popular")]
    public bool Popular { get; set; }

    [Display(Name = "Featured")]
    public bool Featured { get; set; }



    public ICollection<int> SelectedCategoryIds { get; set; } = new List<int>();

    public IEnumerable<CategoryEntity> Categories { get; set; } = new List<CategoryEntity>();


    public IEnumerable<SelectListItem> CategorySelectListItems
    {
        get
        {
            return Categories.Select(c => new SelectListItem
            {
                Value = c.Id.ToString(),
                Text = c.Name
            });
        }
    }

    public ProductRegisterViewModel(IEnumerable<CategoryEntity> categories)
    {
        Categories = categories;
    }




    public static implicit operator ProductEntity(ProductRegisterViewModel productRegisterViewModel)
    {
        var product = new ProductEntity
        {
            Name = productRegisterViewModel.Name,
            Description = productRegisterViewModel.Description,
            Price = productRegisterViewModel.Price,
            ImageUrl = productRegisterViewModel.ImageUrl
        };

        if (productRegisterViewModel.SelectedCategoryIds != null)
        {
            product.ProductCategories = productRegisterViewModel.SelectedCategoryIds
                .Select(x => new ProductCategoryEntity { ProductId = product.Id, CategoryId = x })
                .ToList();
        }

        return product;
    }
}